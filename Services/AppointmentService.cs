using HeathCare.DataBaseSettings;
using HeathCare.Models;
using MongoDB.Driver;

namespace HeathCare.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IAppointmentDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _appointments = database.GetCollection<Appointment>(settings.AppointmentCollectionName);
        }

        public Appointment Create(Appointment appointment)
        {
            _appointments.InsertOne(appointment);
            return appointment;
        }

        public List<Appointment> Get()
        {
            return _appointments.Find(appointment => true).ToList();
        }

        public Appointment Get(string id)
        {
            return _appointments.Find(appointment => appointment.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _appointments.DeleteOne(appointment => appointment.Id == id);
        }

        public void Update(string id, Appointment updatedAppointment)
        {
            updatedAppointment.Id = id;
            _appointments.ReplaceOne(appointment => appointment.Id == id, updatedAppointment);
        }
    }
}

