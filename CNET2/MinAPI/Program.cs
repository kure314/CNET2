using WPFtextGUI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();



var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/hello", () => "Hello");


//POST-> /stats
//GET-> /stats/5
//GET-> /stats/all

app.MapPost("/stats", (StatsResult StatsResultPrijaty) =>
 {
     return "ok";
 });


app.MapGet("/stats/{id}", (int id) => 
{ 
    WPFtextGUI.Model.StatsResult sr = new WPFtextGUI.Model.StatsResult();
    sr.Id = id;
    sr.Source = "dummy result";

    return sr;  //vrátím výsledek
});

app.MapGet("/stats/all", () =>
{
    return GgetAllResults();
});


////poslat statistiku
//app.MapPost("/stats", () =>

//);

app.Run();


static List<StatsResult> GgetAllResults()
{
    return new List<StatsResult>()
    {
        new StatsResult(){Id=1, Source="dummy result 1"},
        new StatsResult(){Id=2, Source="dummy result 2"},
        new StatsResult(){Id=3, Source="dummy result 3"}
    };
}
internal record PuvodniSablona() 
{

    //app.MapGet("/weatherforecast", () =>
    //{
    //    var forecast = Enumerable.Range(1, 5).Select(index =>
    //       new WeatherForecast
    //       (
    //           DateTime.Now.AddDays(index),
    //           Random.Shared.Next(-20, 55),
    //           summaries[Random.Shared.Next(summaries.Length)]
    //       ))
    //        .ToArray();
    //    return forecast;
    //})
    //.WithName("GetWeatherForecast");
}


internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}