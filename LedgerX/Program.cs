using Application.Custumers;
using Infrastructure;
using Infrastructure.Repositories.Custumers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(connectionString)
    );

builder.Services.AddTransient<ICustumerRepository, CustumerRepository>();
builder.Services.AddTransient<ICustumerApplication, CustumerApplication>();


var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
