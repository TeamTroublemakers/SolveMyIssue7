using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Models
{
    public class Issue
    {
		[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
		public ObjectId Id { get; private set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public string? Category { get; set; }
		public DateTime Created { get; set; }
		public List<string>? Solutions { get; set; } = new List<string>();



		public Issue()
		{
			Created = DateTime.UtcNow;
		}

		public Issue(string title, string description, string? category = null)
		{
			Title = title;
			Description = description;
			Category = category;
			Created = DateTime.UtcNow;
		
		}

	}

}
