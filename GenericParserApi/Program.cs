using GenericParserApi.Parsers;
using GenericParserApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Rejestracja kontrolerów oraz konfiguracja wyświetlania enumów jako tekst w JSON.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Rejestracja Swaggera.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Rejestracja usług i parserów w kontenerze Dependency Injection.
builder.Services.AddScoped<IParserService, ParserService>();
builder.Services.AddScoped<ICsvParser, CsvParser>();
builder.Services.AddScoped<IJsonParser, JsonParser>();

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Włączenie Swaggera w środowisku deweloperskim.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
