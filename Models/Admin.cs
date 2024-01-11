using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HeathCare.Models
{
    [BsonIgnoreExtraElements]
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [BsonElement("email")]
        [EmailAddress]
        public string Email { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("phone")]
        [Phone]
        public string Phone { get; set; }

        [BsonElement("photoUrl")]
        public string? PhotoUrl { get; set; }

        [BsonElement("password")]
        [Required]
        public string Password { get; set; }
    }

}
