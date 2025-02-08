using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Sklad.Components;
using Sklad.Components.Data;
using Sklad.Components.Interfaces;
using Sklad.Components.Models;
using Sklad.Components.Pages;
using Sklad.Components.Repositories;
using Sklad.Components.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddValidatorsFromAssemblyContaining<Edit.ToolModelFluentValidator>();


// OpenAI Key
var openAiApiKey = builder.Configuration["OpenAi:ApiKey"];
if (string.IsNullOrEmpty(openAiApiKey))
{
    throw new Exception("OpenAI API key is missing in configuration.");
}

// SignalR + Services
builder.Services.AddSignalR();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITollRepository, ToolRepository>();
builder.Services.AddScoped<ToolService>();

// OpenAI Service
builder.Services.AddHttpClient("OpenAi");
builder.Services.AddScoped<OpenAiService>(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("OpenAi");
    httpClient.Timeout = TimeSpan.FromSeconds(30);
    return new OpenAiService(httpClient, openAiApiKey);
});

// PostgreSQL
var connectionString2 = builder.Configuration.GetConnectionString("DefaultConnection2");
if (string.IsNullOrEmpty(connectionString2))
{
    throw new Exception("Database connection string is missing in configuration.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString2));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
