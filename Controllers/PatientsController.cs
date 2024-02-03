using HeathCare.Models;
using HeathCare.Services;
using HeathCare_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public ActionResult<List<Patient>> Get()
        {
            return patientService.Get();
        }

        // GET api/<PatientsController>/5
        [HttpGet("{setntVal}")]
        public ActionResult<Patient> Get(string setntVal)
        {
            var patient = patientService.Get(setntVal);

            if (patient == null)
            {
                return NotFound($"Patient with Id = {setntVal} not found");
            }

            return patient;
        }

        [HttpGet("ByUserName/{UserName}")]
        public ActionResult<Patient> GetByUserName(string UserName)
        {
            var patient = patientService.Search(UserName);

            if (patient == null)
            {
                return NotFound($"Patient with UserName = {UserName} not found");
            }

            return patient;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            var patient = patientService.Authenticate(login.UserName, login.Password);

            if (patient == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // If authentication succeeds, return some token or a success message
            // You may consider using JWT tokens or other authentication mechanisms here

            // Fo
            // r example, return a success message with the admin details
            return Ok(new { Message = "Authentication successful", Patient = patient });
        }

        // POST api/<PatientsController>
        [HttpPost]
        public async Task<ActionResult<Patient>> Post([FromForm] Patient patient, IFormFile photo)
        {
            if (photo != null)
            {
                var AbsolutePath = "C:\\Program Files\\installed apps\\Linux comanned\\crzylearning\\DotNet Apps\\HealthCareApp\\wwwroot";
                var fileName = $"{patient.Id}_{photo.FileName}";
                var filePath = Path.Combine(AbsolutePath, "photos", "Patients", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Patients/{fileName}"; // Constructing the URL where the photo will be accessible

                patient.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            patientService.Create(patient);

            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }


        // PUT api/<PatientsController>/5

        [HttpPut("{id}")]
        public async Task<ActionResult<Patient>> Put(string id,[FromForm] Patient updatedPatient, IFormFile photo)
        {
            var existingPatient = patientService.Get(id);
            if (existingPatient == null)
            {
                return NotFound($"Patient with Id = {id} not found");
            }

            if (photo != null)
            {
                var AbsolutePath = "C:\\Program Files\\installed apps\\Linux comanned\\crzylearning\\DotNet Apps\\HealthCareApp\\wwwroot";
                var fileName = $"{updatedPatient.Id}_{photo.FileName}";
                var filePath = Path.Combine(AbsolutePath, "photos", "Patients", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/photos/Patients/{fileName}"; // Constructing the URL where the photo will be accessible

                updatedPatient.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            patientService.Update(id, updatedPatient);

            return Ok($"Patient with Id = {id} updated");
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var patient = patientService.Get(id);

            if (patient == null)
            {
                return NotFound($"patient with Id = {id} not found");
            }

            patientService.Remove(patient.Id);

            return Ok($"patient with Id = {id} deleted");
        }
    }
}
