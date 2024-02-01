using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SolveMyIssue7.DataAccess.Models;

namespace SolveMyIssue7.DataAccess.Services
{
    public class AuthenticationService
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

    }

}