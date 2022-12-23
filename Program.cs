using Microsoft.EntityFrameworkCore;
using BackendData.Persistence;
using BackendData.Services;
using BackendData.Domain.Services;
using BackendData.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("ApiDatabase");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BackendData.Persistence.AppDbContext>(options=>
                 options.UseSqlServer(connString)
              );
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors();              
builder.Services.AddRouting(options => options.LowercaseUrls = true);
            
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
                
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
