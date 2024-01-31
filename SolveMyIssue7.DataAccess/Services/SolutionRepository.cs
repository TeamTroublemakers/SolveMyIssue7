﻿using MongoDB.Driver;
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
	public class SolutionRepository : ISolutionRepository
	{
		private readonly IMongoCollection<Solution> _solutionCollection;

        public SolutionRepository()
        {
			var databaseName = "SolveMyIssue";
			var collectionName = "Solutions";

			var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
			_solutionCollection = mongoDatabase.GetCollection<Solution>(collectionName);
		}


		public async Task AddAsync(Solution entity)
		{
			await _solutionCollection.InsertOneAsync(entity);
		}

		public async Task DeleteAsync(string id)
		{
			await _solutionCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Solution>> GetAllAsync()
		{
			return await _solutionCollection.Find(x => true).ToListAsync();
		}

		public async Task<Solution> GetByIdAsync(string id)
		{
			return await _solutionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(Solution entity)
		{
			await _solutionCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		}

		
	}
}
