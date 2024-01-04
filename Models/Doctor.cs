using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Doctor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("speciality")]
        public string Speciality { get; set; }

        [BsonElement("languageSpoken")]
        public List<string> LanguageSpoken { get; set; }

        [BsonElement("availableDate")]
        public DateTime AvailableDate { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("photoUrl")]
        public string? PhotoUrl { get; set; }

        [BsonElement("appointments")]
        public List<ObjectId>? Appointments { get; set; } // References to Appointments

        [BsonElement("chats")]
        public List<ObjectId>? Chats { get; set; } // References to Chats

        [BsonElement("posts")]
        public List<ObjectId>? Posts { get; set; } // References to Posts
    }

}
