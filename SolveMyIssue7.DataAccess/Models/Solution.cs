using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
    public class Solution
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
      
        [BsonRepresentation(BsonType.ObjectId)]
        public string IssueId { get; set; }
        public string Text { get; set; }
        public List<string>? Comments = new List<string>();
    }
}