﻿using HeathCare.Models;
using HeathCare.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(string id)
        {
            var doctor = doctorService.Get(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            return doctor;
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> Post([FromForm] Doctor doctor, IFormFile photo)
        {
            if (photo != null)
            {
                var fileName = $"{doctor.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos", "Doctors", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/wwwroot/photos/Doctors/{fileName}"; // Constructing the URL where the photo will be accessible

                doctor.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            doctorService.Create(doctor);

            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctors/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Doctor updatedDoctor)
        {
            var existingDoctor = doctorService.Get(id);

            if (existingDoctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            doctorService.Update(id, updatedDoctor);

            return Ok($"Doctor with Id = {id} updated");
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