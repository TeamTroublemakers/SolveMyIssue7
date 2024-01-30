using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Services
{
	public class OrganizationRepository : IOrganizationRepository
	{
		private readonly IMongoCollection<Organization> _organizationCollection;


		public OrganizationRepository(IMongoDatabase db)
		{
			var collectionName = "Organization";

			_organizationCollection = db.GetCollection<Organization>(collectionName);
		}
		public async Task AddAsync(Organization entity)
		{
			await _organizationCollection.InsertOneAsync(entity);
		}

		public async Task DeleteAsync(string id)
		{
			await _organizationCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Organization>> GetAllAsync()
		{
			return await _organizationCollection.Find(x => true).ToListAsync();
		}

		public async Task<Organization> GetByIdAsync(string id)
		{
			return await _organizationCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(Organization entity)
		{
			await _organizationCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
		}
	}
}
