﻿using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.Common.Interfaces;
using SolveMyIssue7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolveMyIssue7.Common.Util;

namespace SolveMyIssue7.DataAccess.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly IMongoCollection<User> _userCollection;

		public UserRepository(IMongoClient client)
		{
			var databaseName = "SolveMyIssue";
			var collectionName = "Issues";

			var db = client.GetDatabase(databaseName);
			_userCollection = db.GetCollection<User>(collectionName);
		}

		public async Task<Result> RegisterAsync(User user)
		{
			try
			{
				user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

				await _userCollection.InsertOneAsync(user);
				return new Result("User registered", true);
			}
			catch (Exception e)
			{
				return new Result(e.Message, false);
			}
		}

		public async Task<Result> LoginAsync(string email, string password)
		{
			var userFromDb = await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
			if (userFromDb == null) return new Result("User not found", false);

			if (!BCrypt.Net.BCrypt.Verify(password, userFromDb.Password))
			{
				return new Result("Invalid password", false);
			}

			return new Common.Util.Result("Login successful", true);
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

		public async Task UpdateAsync(User user)
		{
			await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
		}

		public Task AddAsync(User user)
		{
			throw new NotImplementedException();
		}
	}
}
