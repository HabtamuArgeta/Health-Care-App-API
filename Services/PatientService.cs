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

            public Patient Get(string id)
            {
                return _patients.Find(patient => patient.Id == id).FirstOrDefault();
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
