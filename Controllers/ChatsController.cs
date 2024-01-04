using HeathCare.Models;
using HeathCare.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HeathCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatsController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        // GET: api/Chats
        [HttpGet]
        public ActionResult<List<Chat>> Get()
        {
            return chatService.Get();
        }

        // GET: api/Chats/{id}
        [HttpGet("{id}")]
        public ActionResult<Chat> Get(string id)
        {
            var chat = chatService.Get(id);

            if (chat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            return chat;
        }

        // POST: api/Chats
        [HttpPost]
        public async Task<ActionResult<Chat>> Post([FromForm] Chat chat)
        {
            chatService.Create(chat);

            return CreatedAtAction(nameof(Get), new { id = chat.Id }, chat);
        }

        // PUT: api/Chats/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Chat updatedChat)
        {
            var existingChat = chatService.Get(id);

            if (existingChat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            chatService.Update(id, updatedChat);

            return Ok($"Chat with Id = {id} updated");
        }

        // DELETE: api/Chats/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var chat = chatService.Get(id);

            if (chat == null)
            {
                return NotFound($"Chat with Id = {id} not found");
            }

            chatService.Remove(id);

            return Ok($"Chat with Id = {id} deleted");
        }
    }
}
