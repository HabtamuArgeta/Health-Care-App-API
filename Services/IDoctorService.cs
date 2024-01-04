using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IDoctorService
    {
        List<Doctor> Get();
        Doctor Get(string id);
        Doctor Create(Doctor doctor);
        void Update(string id, Doctor doctor);
        void Remove(string id);
    }
}
