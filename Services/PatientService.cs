using HeathCare.DataBaseSettings;
using HeathCare.Models;
using MongoDB.Driver;
using static HeathCare.Services.PatientService;

namespace HeathCare.Services
{
    public class PatientService : IPatientService
    {
            private readonly IMongoCollection<Patient> _patients;

            public PatientService(IPatientDatabaseSettings settings, IMongoClient mongoClient)
            {
                var database = mongoClient.GetDatabase(settings.DatabaseName);
               _patients = database.GetCollection<Patient>(settings.PatientCollectionName);
            }

            public Patient Create(Patient patient)
            {
                _patients.InsertOne(patient);
                return patient;
            }

          public List<Patient> Get()
            {
                return _patients.Find(patient => true).ToList();
            }

        public Patient Get(string setntVal)
        {
            Patient patient;
            patient = _patients.Find(patient => patient.UserName == setntVal).FirstOrDefault();
            if (patient != null)
            {
                return patient;
            }
            return _patients.Find(a => a.Id == setntVal).FirstOrDefault();
        }
        public Patient Search(string UserName)
        {
            Patient patient;
            patient = _patients.Find(patient => patient.UserName == UserName).FirstOrDefault();
            if (patient != null)
            {
                return patient;
            }
            return null;

        }
        public Patient Authenticate(string username, string password)
        {
            var patient = _patients.Find(a => a.UserName == username).FirstOrDefault();

            if (patient != null && patient.Password == password)
            {
                // Authentication successful, return the admin details
                return patient;
            }

            // If the username or password is incorrect, return null
            return null;
        }

        public void Remove(string id)
            {
               _patients.DeleteOne(patient => patient.Id == id);
            }

            public void Update(string id, Patient updatedPatient)
            {
                updatedPatient.Id = id; 
               _patients.ReplaceOne(student => student.Id == id, updatedPatient);
            }
    }
}
