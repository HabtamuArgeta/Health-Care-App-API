using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        [EmailAddress]
        public string Email { get; set; }

        [BsonElement("phone")]
        [Phone]
        public string Phone { get; set; }

        [BsonElement("photoUrl")]
        public string? PhotoUrl { get; set; }

        [BsonElement("appointments")]
        public List<ObjectId>? Appointments { get; set; } // References to Appointments

        [BsonElement("chats")]
        public List<ObjectId>? Chats { get; set; } // References to Chats
    }

}
