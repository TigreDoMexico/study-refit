using ExampleCode.Core.Pokemon.HttpClient;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRefitClient<IPokeApi>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new  Uri(builder.Configuration["PokeApiUrl"]);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
