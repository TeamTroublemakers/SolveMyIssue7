using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace SolveMyIssue7.DataAccess.Auth
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IMongoCollection<Role> _rolesCollection;

        public RoleStore(IMongoCollection<Role> rolesCollection)
        {
            _rolesCollection = rolesCollection;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            await _rolesCollection.InsertOneAsync(role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await _rolesCollection.DeleteOneAsync(r => r.Id == role.Id, cancellationToken);
            return result.DeletedCount == 1 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = $"Could not delete role with id {role.Id}." });
        }

        public void Dispose()
        {
            // Inget behov av att disponera något här eftersom MongoDB driver hanterar anslutningspoolen automatiskt.
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await _rolesCollection.Find(r => r.Id == roleId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _rolesCollection.Find(r => r.NormalizedName == normalizedRoleName).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await _rolesCollection.ReplaceOneAsync(r => r.Id == role.Id, role, cancellationToken: cancellationToken);
            return result.ModifiedCount == 1 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = $"Could not update role with id {role.Id}." });
        }
    }

}
