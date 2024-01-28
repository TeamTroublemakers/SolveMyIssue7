using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.Common.Interfaces;
using SolveMyIssue7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly IMongoCollection<User> _userCollection;

        public UserRepository()
        {
			var databaseName = "SolveMyIssue";
			var collectionName = "Issues";

			var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
			var mongoDatabase = mongoClient.GetDatabase(databaseName);
			_userCollection = mongoDatabase.GetCollection<User>(collectionName);
		}


		public async Task AddAsync(User entity)
		{
			await _userCollection.InsertOneAsync(entity);
		}

		public async Task DeleteAsync(string id)
		{
			await _userCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _userCollection.Find(x => true).ToListAsync();
		}

		public async Task<User> GetByIdAsync(string id)
		{
			return await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync( User entity)
		{
			await _userCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		}

		Task IRepository<User>.UpdateAsync(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
