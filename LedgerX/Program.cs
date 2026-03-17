using Application.Custumers;
using Application.ShopSettings;
using Application.Transactions;
using Application.Users;
using Infrastructure;
using Infrastructure.Repositories.Custumers;
using Infrastructure.Repositories.ShopSettings;
using Infrastructure.Repositories.Transactions;
using Infrastructure.Repositories.Users;
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
builder.Services.AddTransient<IShopSettingsApplication, ShopSettingsApplication>();
builder.Services.AddTransient<IShopSettingsRepository, ShopSettingsRepository>();
builder.Services.AddTransient<IUserApplication, UserApplication>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ITransactionsApplication, TransactionsApplication>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();


var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
