using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IAdminService
    {
        List<Admin> Get();
        Admin Get(string id);
        Admin Create(Admin admin);
        void Update(string id, Admin admin);
        void Remove(string id);
    }
}
