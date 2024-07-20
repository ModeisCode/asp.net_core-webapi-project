using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication1.Models
{
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public int? age { get; set; }
        public string? city { get; set; }
    }
}
