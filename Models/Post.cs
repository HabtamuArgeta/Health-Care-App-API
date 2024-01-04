using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("postPhoto")]
        public string? PhotoUrl { get; set; }

        [BsonElement("datePublished")]
        public DateTime DatePublished { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("likes")]
        public int? Likes { get; set; }

        [BsonElement("doctorId")]
        public ObjectId? DoctorId { get; set; } // Reference to Doctor
    }

}
