using HeathCare.Models;

namespace HeathCare.Services
{
    public interface IAppointmentService
    {
        List<Appointment> Get();
        Appointment Get(string id);
        Appointment  Create(Appointment appointment);
        void Update(string id, Appointment appointment);
        void Remove(string id);
    }
}
