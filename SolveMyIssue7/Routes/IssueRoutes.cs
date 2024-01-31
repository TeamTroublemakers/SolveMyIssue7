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

			//         //app.MapDelete()


			//         public async Task AddAsync(Issue entity)
			//         {
			//             await _issueCollection.InsertOneAsync(entity);
			//         }

			//         public async Task DeleteAsync(string id)
			//         {
			//             await _issueCollection.DeleteOneAsync(x => x.Id.ToString() == id);
			//         }



			//         public async Task<Issue> GetByIdAsync(string id)
			//         {
			//             return await _issueCollection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();
			//         }

			//         public async Task UpdateAsync(Issue entity)
			//         {
			//             await _issueCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
			//         }
			//     }
		}

	}
}
