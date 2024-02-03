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

        public Doctor Get(string setntVal)
        {
            Doctor doctor;
            doctor = _doctors.Find(doctor => doctor.UserName == setntVal).FirstOrDefault();
            if (doctor != null)
            {
                return doctor;
            }
            return _doctors.Find(a => a.Id == setntVal).FirstOrDefault();
        }


        public Doctor Search(string UserName)
        {
            Doctor doctor;
            doctor  = _doctors.Find(doctor => doctor.UserName == UserName).FirstOrDefault();
            if (doctor != null)
            {
                return doctor;
            }
            return null;
            
        }
        public Doctor Authenticate(string username, string password)
        {
            var doctor= _doctors.Find(d => d.UserName == username).FirstOrDefault();

            if (doctor != null && doctor.Password == password)
            {
                // Authentication successful, return the admin details
                return doctor;
            }

            // If the username or password is incorrect, return null
            return null;
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

