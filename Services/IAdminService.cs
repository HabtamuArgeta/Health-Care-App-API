using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IAdminService
    {
        List<Admin> Get();
        Admin Get(string id);
        Admin Create(Admin admin);
        Admin Authenticate(string username, string password);
       // Admin GetByUserName(string username);
        void Update(string id, Admin admin);
        void Remove(string id);
    }
}
