using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Appointment
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("doctorUserName")]
        public string DoctorUserName { get; set; }

        [BsonElement("patientUserName")]
        public string PatientUserName { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        
    }

}
