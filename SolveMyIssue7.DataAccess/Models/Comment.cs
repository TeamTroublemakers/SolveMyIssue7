using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id;
        [BsonRepresentation(BsonType.ObjectId)]
        private string _userId;
        [BsonRepresentation(BsonType.ObjectId)]
        private string _issueId;
        [BsonRepresentation(BsonType.ObjectId)]
        private string? _solutionId;
        private string _text;

        private List<string> _likeIds;

        public Comment(string userId, string issueId, string text)
        {
   
            _userId = userId;
            _issueId = issueId;
            _text = text;
            _likeIds = new List<string>();
        }

        //public Comment(string userId, string solutionId, string text)
        //{
        //    _id = Guid.NewGuid();
        //    _userId = userId;
        //    _solutionId = solutionId;
        //    _text = text;
        //    _likeIds = new List<string>();
        //}
    }
}