using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
        public class User
        {
                [BsonId]
                [BsonRepresentation(BsonType.ObjectId)]
                public string Id { get; set; }

                public string Name { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
                public List<string> IssueIds { get; set; }
                public List<string> SolutionIds { get; set; }
                public List<string> CommentIds { get; set; }
                public List<string> LikeIds { get; set; }
                public List<string> OrganizationIds { get; set; }

                public User(string name, string email, string password)
                {
                        Name = name;
                        Email = email;
                        Password = password;
                        IssueIds = new List<string>();
                        SolutionIds = new List<string>();
                        CommentIds = new List<string>();
                        LikeIds = new List<string>();
                }

                public User()
                {

                }

                //public User(string name, string email, string password)
                //{
                //	Name = name;
                //	Email = email;
                //	Password = password;
                //}
        }
}