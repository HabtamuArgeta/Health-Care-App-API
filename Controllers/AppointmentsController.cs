using HeathCare.Models;
using HeathCare.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public ActionResult<List<Appointment>> Get()
        {
            return appointmentService.Get();
        }

        // GET: api/Appointments/{id}
        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }

            return appointment;
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> Post([FromForm] Appointment appointment)
        {

            appointmentService.Create(appointment);

            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> Put(string id, [FromForm] Appointment updatedAppointment)
        {
            var existingappointment = appointmentService.Get(id);

            if (existingappointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }


            appointmentService.Update(id, updatedAppointment);

            return Ok($"Appointment with Id = {id} updated");
        }
        

        // DELETE: api/Appointments/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var appointment = appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with Id = {id} not found");
            }

            appointmentService.Remove(id);

            return Ok($"Appointment with Id = {id} deleted");
        }
    }
}
