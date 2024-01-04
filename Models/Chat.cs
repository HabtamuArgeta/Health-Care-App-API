using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("doctorId")]
        public ObjectId? DoctorId { get; set; } // Reference to Doctor

        [BsonElement("patientId")]
        public ObjectId? PatientId { get; set; } // Reference to Patient

        [BsonElement("message")]
        public string Message { get; set; }
    }

}
