using Microsoft.AspNetCore.Mvc;
using SolveMyIssue7.DataAccess.Models;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.DataAccess.Services;

namespace SolveMyIssue7.Routes
{
    public static class SolutionRoutes
    {
        //public static void MapSolutionEndpoint(this WebApplication app)
        //{
        //    app.MapGet("/solutions", async ([FromServices] ISolutionRepository solutionRepository) =>
        //    {
        //        return await solutionRepository.GetAllAsync();
        //    });

        //    app.MapPost("/solution", async ([FromServices] ISolutionRepository solutionRepository, Solution newSolution) =>
        //    {
        //        await solutionRepository.AddAsync(newSolution);
        //    });

        //    app.MapPut("/solution", async ([FromServices] ISolutionRepository solutionRepository, Solution updatedSolution) =>
        //    {
        //        await solutionRepository.UpdateAsync(updatedSolution);
        //    });

        //    app.MapDelete("/solution", async ([FromServices] ISolutionRepository solutionRepository, string id) =>
        //    {
        //        await solutionRepository.DeleteAsync(id);
        //    });

        //}
    }
}