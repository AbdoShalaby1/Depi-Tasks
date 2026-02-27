using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TMS_2_with_middleware.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // this will be auto generated, BsonRepresentation is for string display (default is binary)
        public string Id { get; set; } = null!;
        [BsonRequired]
        public required string Name { get; set; }
        // I know it's bad not to hash it, I know, just for testing purposes
        [BsonRequired]
        public required string Password { get; set; }
        [BsonRequired]
        [EmailAddress]
        public required string Email { get; set; }

    }
}
