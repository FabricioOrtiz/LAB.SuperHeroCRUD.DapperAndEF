using LAB.SuperHeroCRUD.Persistence;
using LAB.SuperHeroCRUD.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Aqui hacemos todas las inyeccion de dependencias
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<DBContext>());
builder.Services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
builder.Services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();

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
