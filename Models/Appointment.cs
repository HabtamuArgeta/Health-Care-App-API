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

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("doctorId")]
        public ObjectId? DoctorId { get; set; } // Reference to Doctor

        [BsonElement("patientId")]
        public ObjectId? PatientId { get; set; } // Reference to Patient

        [BsonElement("timeRange")]
        public string TimeRange { get; set; }
    }

}
