using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebScarp.Entities.Entites

{
    public class News
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        public string Head { get; set; } = null!;
        public string Contents { get; set; } = null!;

    }
}