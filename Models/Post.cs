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

        [BsonElement("doctorUserName")]
        public string DoctorUserName { get; set; }

        [BsonElement("postPhoto")]
        public string? PhotoUrl { get; set; }

        [BsonElement("datePublished")]
        public string DatePublished { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        
    }

}
