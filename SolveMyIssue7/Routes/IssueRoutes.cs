using SolveMyIssue7.DataAccess.Services;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.DataAccess.Models;
using System.Runtime.CompilerServices;
using SolveMyIssue7.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace SolveMyIssue7.Routes
{
	public static class IssueRoutes
	{
		public static void MapIssueEndpoints(this WebApplication app)
		{
			app.MapGet("issues", async ([FromServices] IIssueRepository issueRepository) =>
			{
				return await issueRepository.GetAllAsync();
			});

			app.MapPost("issue", async ([FromServices] IIssueRepository issueRepository, Issue newIssue) =>
			{
				await issueRepository.AddAsync(newIssue);
			});
		}
	}

}
