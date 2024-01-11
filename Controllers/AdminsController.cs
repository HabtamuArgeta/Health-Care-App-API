using HeathCare.Models;
using HeathCare.Services;
using Microsoft.AspNetCore.Mvc;


namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: api/Admins
        [HttpGet]
        public ActionResult<List<Admin>> Get()
        {
            return adminService.Get();
        }

        // GET: api/Admins/{id}
        [HttpGet("{id}")]
        public ActionResult<Admin> Get(string id)
        {
            var admin = adminService.Get(id);

            if (admin == null)
            {
                return NotFound($"Admin with Id = {id} not found");
            }

            return admin;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            var admin = adminService.Authenticate(login.UserName, login.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // If authentication succeeds, return some token or a success message
            // You may consider using JWT tokens or other authentication mechanisms here

            // For example, return a success message with the admin details
            return Ok(new { Message = "Authentication successful", Admin = admin });
        }


        // POST: api/Admins
        // POST api/<PatientsController>
        [HttpPost]
        public async Task<ActionResult<Admin>> Post([FromForm] Admin admin, IFormFile photo)
        {
            if (photo != null)
            {
                var fileName = $"{admin.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos","Admins", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/wwwroot/photos/Admins/{fileName}"; // Constructing the URL where the photo will be accessible

                admin.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            adminService.Create(admin);

            return CreatedAtAction(nameof(Get), new { id = admin.Id }, admin);
        }

        // PUT: api/Admins/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> Put(string id, [FromForm] Admin updatedAdmin,IFormFile photo)
        {
            var existingAdmin = adminService.Get(id);

            if (existingAdmin == null)
            {
                return NotFound($"Admin with Id = {id} not found");
            }

            if (photo != null)
            {
                var fileName = $"{updatedAdmin.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos", "Admins", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                     await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/wwwroot/photos/Admins/{fileName}"; // Constructing the URL where the photo will be accessible

                updatedAdmin.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            adminService.Update(id, updatedAdmin);

            return Ok($"Admin with Id = {id} updated");
        }

        // DELETE: api/Admins/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var admin = adminService.Get(id);

            if (admin == null)
            {
                return NotFound($"Admin with Id = {id} not found");
            }

            adminService.Remove(id);

            return Ok($"Admin with Id = {id} deleted");
        }
    }

    public class Login
    {
        public string UserName { get; set; }

        
        public string Password { get; set; }
    }
}
