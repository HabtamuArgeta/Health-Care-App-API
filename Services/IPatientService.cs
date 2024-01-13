using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IPatientService
    {
        List<Patient> Get();
        Patient Get(string id);
        Patient Create(Patient patient);
        Patient Authenticate(string username, string password);
        void Update(string id, Patient patient);
        void Remove(string id);
    }
}
