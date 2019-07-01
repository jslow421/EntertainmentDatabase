using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntertainmentDatabase.Core.Models
{
    public class MovieModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Title")]
        public string Title { get; set; }
        
        [BsonElement("Upc")]
        public string Upc { get; set; }
        
        [BsonElement("Ean")]
        public string Ean { get; set; }
        
        [BsonElement("Description")]
        public string Description { get; set; }
    }
}