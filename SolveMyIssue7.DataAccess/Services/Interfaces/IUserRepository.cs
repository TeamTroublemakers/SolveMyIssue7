﻿using SolveMyIssue7.Common.Interfaces;
using SolveMyIssue7.Common.Util;
using SolveMyIssue7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveMyIssue7.DataAccess.Services.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		Task<Result> RegisterAsync(User user);
		Task<Result> LoginAsync(string email, string password);
	}
}
