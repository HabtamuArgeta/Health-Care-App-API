using HeathCare.DataBaseSettings;
using HeathCare.Models;
using MongoDB.Driver;

namespace HeathCare.Services
{
    public class ChatService : IChatService
    {
        private readonly IMongoCollection<Chat> _chats;

        public ChatService(IChatDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _chats = database.GetCollection<Chat>(settings.ChatCollectionName);
        }

        public Chat Create(Chat chat)
        {
            _chats.InsertOne(chat);
            return chat;
        }

        public List<Chat> Get()
        {
            return _chats.Find(chat => true).ToList();
        }

        public Chat Get(string id)
        {
            return _chats.Find(chat => chat.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _chats.DeleteOne(chat => chat.Id == id);
        }

        public void Update(string id, Chat updatedChat)
        {
            updatedChat.Id = id;
            _chats.ReplaceOne(chat => chat.Id == id, updatedChat);
        }
    }
}

