using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
    [BsonIgnoreExtraElements]
    public class Solution
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
      
        [BsonRepresentation(BsonType.ObjectId)]
        public string IssueId { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public int Likes { get; set; }
        public int Dislikes { get; set; }
      
    }
}