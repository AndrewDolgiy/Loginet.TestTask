using Loginet.TestTask.Api.Interfaces;
using Loginet.TestTask.Api.Services;
using Microsoft.EntityFrameworkCore;
using Refit;
using TestTask.Loginet.Data.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceDb"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services
    .AddRefitClient<IJsonPlaceHolderApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["JsonHolderUrl"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()
    || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
