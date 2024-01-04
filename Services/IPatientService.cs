using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IPatientService
    {
        List<Patient> Get();
        Patient Get(string id);
        Patient Create(Patient patient);
        void Update(string id, Patient patient);
        void Remove(string id);
    }
}
