using CodeCrunch.Services;
using CodeCrunch.Services.CoinPaprika;
using CodeCrunch.Services.NASA;
using CodeCrunch.Services.OpenWeather;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CodeCrunch", Version = "v1" });
});
builder.Services.AddSingleton<ITwitterService, TwitterService>();
builder.Services.AddSingleton<INASAService, NASAService>();
builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
builder.Services.AddSingleton<ICoinPaprikaService, CoinPaprikaService>();
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeCrunch v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
