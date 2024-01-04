using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IChatService
    {
        List<Chat> Get();
        Chat Get(string id);
        Chat Create(Chat chat);
        void Update(string id, Chat chat);
        void Remove(string id);
    }
}
