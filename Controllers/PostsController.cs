using HeathCare.Models;
using HeathCare.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return postService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get(string id)
        {
            var post = postService.Get(id);

            if (post == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            return post;
        }

        [HttpPost]

        public async Task<ActionResult<Post>> Post([FromForm] Post post, IFormFile photo)
        {
            if (photo != null)
            {
                var fileName = $"{post.Id}_{photo.FileName}";
                var filePath = Path.Combine("wwwroot", "photos", "Posts", fileName); // Specify the directory where photos will be saved

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var photoUrl = $"/wwwroot/photos/Posts/{fileName}"; // Constructing the URL where the photo will be accessible

                post.PhotoUrl = photoUrl; // Save the photo URL to the Student model
            }

            postService.Create(post);

            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }


        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Post updatedPost)
        {
            var existingPost = postService.Get(id);

            if (existingPost == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            postService.Update(id, updatedPost);

            return Ok($"Post with Id = {id} updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var post = postService.Get(id);

            if (post == null)
            {
                return NotFound($"Post with Id = {id} not found");
            }

            postService.Remove(id);

            return Ok($"Post with Id = {id} deleted");
        }
    }
}
