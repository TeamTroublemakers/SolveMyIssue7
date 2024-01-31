using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.DataAccess.Models;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SolveMyIssue7.DataAccess.Services
{
	public class IssueRepository : IIssueRepository
	{
		private readonly IMongoCollection<Issue> _issueCollection;
        private readonly IMongoCollection<Solution> _solutionCollection;
        public IssueRepository()
		{
			
			var databaseName = "SolveMyIssue";
			var collectionName = "Issues";

			var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
			var mongoDatabase = mongoClient.GetDatabase(databaseName);
			_issueCollection = mongoDatabase.GetCollection<Issue>(collectionName);

		}

		public async Task AddAsync(Issue entity)
		{
			await _issueCollection.InsertOneAsync(entity);
		}

		public async Task DeleteAsync(string id)
		{
			await _issueCollection.DeleteOneAsync(x => x.Id.ToString() == id);
		}

		public async Task<IEnumerable<Issue>> GetAllAsync()
		{
			return await _issueCollection.Find(x => true).ToListAsync();
		}

		public async Task<Issue> GetByIdAsync(string id)
		{
			return await _issueCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(Issue entity)
		{
			await _issueCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		}

        
    }
}
