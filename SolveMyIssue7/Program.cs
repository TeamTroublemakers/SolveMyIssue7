using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using SolveMyIssue7.DataAccess.Auth;
using SolveMyIssue7.DataAccess.Models;
using SolveMyIssue7.DataAccess.Services;
using SolveMyIssue7.DataAccess.Services.Interfaces;
using SolveMyIssue7.Routes;
using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Components.Authorization;

var mongoConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
var db = client.GetDatabase("SolveMyIssue");
builder.Services.AddSingleton(db);

builder.Services.AddSingleton<IIssueRepository, IssueRepository>();
builder.Services.AddSingleton<ISolutionRepository, SolutionRepository>();

// builder.Services.AddIdentity<User, Role>()
// 	.AddUserStore<UserStore>() // Byt ut mot din anpassade UserStore
// 	.AddRoleStore<UserStore>() // Byt ut mot din anpassade RoleStore
// 	.AddDefaultTokenProviders();

// builder.Services.AddIdentity<User, Role>()
// 	.AddMongoDbStores<User, Role, Guid>(mongoConnectionString, "SolveMyIssue")
// 	.AddDefaultTokenProviders();


// builder.Services.AddScoped<AuthenticationService>();
// builder.Services.AddScoped<ISecurityStampValidator, CustomSecurityStampValidator<UserModel>>();



// builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();



// At the ConfigureServices section in Startup.cs
// builder.Services.AddIdentityMongoDbProvider<MongoUser>();

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
