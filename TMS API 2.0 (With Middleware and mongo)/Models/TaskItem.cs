using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TMS_2_with_middleware.Models
{
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // this will be auto generated, BsonRepresentation is for string display (default is binary)
        public string Id { get; set; } = null!;
        [BsonRequired]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [BsonRequired]
        public required DateTime CreatedAt { get; set; }

        [BsonExtraElements]
        public Dictionary<string,object> Extra { get; set; } = new();
        // just to test the functionality and flexibility of Mongo
    }
}
