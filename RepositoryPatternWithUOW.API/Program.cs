using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Mapping;
using RepositoryPatternWithUOW.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 builder.Services.AddDbContext<ApplicationDbContext>( 
     options => options.UseSqlServer(ConnectionString));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();

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


app.UseAuthorization();

app.MapControllers();

app.Run();
