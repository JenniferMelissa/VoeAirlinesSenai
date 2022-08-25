using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//injeção de dependencia da classe VoeAirlines
builder.Services.AddDbContext<VoeAirlinesSenaiContext>();
//injecao de dependencia da classe AeronaveService
builder.Services.AddTransient<AeronaveServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
