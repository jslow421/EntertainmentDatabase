using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntertainmentDatabase.Core.Entities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("Publisher")]
        public string Publisher { get; set; }
    }
}
