using HeathCare.Models;
using HeathCare.Services;
using HeathCare_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;

namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public ActionResult<List<Doctor>> Get()
        {
            return doctorService.Get();
        }

        // GET: api/Doctors/{id}
        [HttpGet("{setntVal}")]
        public ActionResult<Doctor> Get(string setntVal)
        {
            var doctor = doctorService.Get(setntVal);

            if (doctor == null)
            {
                return NotFound($"Doctor with Id = {setntVal} not found");
            }

            return doctor;
        }

        [HttpGet("ByUserName/{UserName}")]
        public ActionResult<Doctor> GetByUserName(string UserName)
        {
            var doctor = doctorService.Search(UserName);

            if (doctor == null)
            {
                return NotFound($"Doctor with UserName = {UserName} not found");
            }

            return doctor;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            var doctor = doctorService.Authenticate(login.UserName, login.Password);

            if (doctor == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // If authentication succeeds, return some token or a success message
            // You may consider using JWT tokens or other authentication mechanisms here

            // For example, return a success message with the admin details
            return Ok(new { Message = "Authentication successful", Doctor = doctor });
        }
        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> Post([FromForm] Doctor doctor, IFormFile photo)
        {
            if (photo != null)
            {
                var AbsolutePath = "C:\\Program Files\\installed apps\\Linux comanned\\crzylearning\\DotNet Apps\\HealthCareApp\\wwwroot";
                var fileName = $"{doctor.Id}_{photo.FileName}";
                var filePath = Path.Combine(AbsolutePath, "photos", "Doctors", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Doctors/{fileName}"; // Constructing the URL where the photo will be accessible

                doctor.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            doctorService.Create(doctor);

            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctors/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> Put(string id, [FromForm] Doctor updatedDoctor, IFormFile photo)
        {
            var existingAdmin = doctorService.Get(id);

            if (existingAdmin == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            if (photo != null)
            {
                var AbsolutePath = "C:\\Program Files\\installed apps\\Linux comanned\\crzylearning\\DotNet Apps\\HealthCareApp\\wwwroot";
                var fileName = $"{updatedDoctor.Id}_{photo.FileName}";
                var filePath = Path.Combine(AbsolutePath, "photos", "Doctors", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Doctors/{fileName}"; // Constructing the URL where the photo will be accessible

                updatedDoctor.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            doctorService.Update(id, updatedDoctor);

            return Ok($"Admin with Id = {id} updated");
        }

        // DELETE: api/Doctors/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var doctor = doctorService.Get(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            doctorService.Remove(id);

            return Ok($"Doctor with Id = {id} deleted");
        }
    }
}
