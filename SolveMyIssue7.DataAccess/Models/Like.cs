using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
    public class Like
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
        [BsonRepresentation(BsonType.ObjectId)]
        private string? _commentId;

        public Like(string userId, string issueId)
        {

            _userId = userId;
            _issueId = issueId;
        }

        //public Like(string userId, string solutionId)
        //{
        //    _id = Guid.NewGuid();
        //    _userId = userId;
        //    _solutionId = solutionId;
        //}

        //public Like(string userId, string commentId)
        //{
        //    _id = Guid.NewGuid();
        //    _userId = userId;
        //    _commentId = commentId;
        //}

    }
}