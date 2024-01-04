using HeathCare.DataBaseSettings;
using HeathCare.Models;
using MongoDB.Driver;

namespace HeathCare.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctors;

        public DoctorService(IDoctorDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _doctors = database.GetCollection<Doctor>(settings.DoctorCollectionName);
        }

        public Doctor Create(Doctor doctor)
        {
            _doctors.InsertOne(doctor);
            return doctor;
        }

        public List<Doctor> Get()
        {
            return _doctors.Find(doctor => true).ToList();
        }

        public Doctor Get(string id)
        {
            return _doctors.Find(doctor => doctor.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _doctors.DeleteOne(doctor => doctor.Id == id);
        }

        public void Update(string id, Doctor updatedDoctor)
        {
            updatedDoctor.Id = id;
            _doctors.ReplaceOne(doctor => doctor.Id == id, updatedDoctor);
        }
    }
}

