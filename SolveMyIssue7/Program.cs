using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Auth;
using SolveMyIssue7.DataAccess.Models;
using SolveMyIssue7.DataAccess.Services;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.Routes;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var localConnectionString = "mongodb://localhost:27017";
var client = new MongoClient(localConnectionString);
var db = client.GetDatabase("SolveMyIssue"); 
builder.Services.AddSingleton(db);

builder.Services.AddSingleton<IIssueRepository, IssueRepository>();
builder.Services.AddSingleton<ISolutionRepository, SolutionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

IssueRoutes.MapIssueEndpoints(app);

//SolutionRoutes.MapSolutionEndpoint(app);

app.Run();
