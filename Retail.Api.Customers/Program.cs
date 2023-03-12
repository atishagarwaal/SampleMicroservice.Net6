//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Retail.Api.Customers.Data;
using Retail.Api.Customers.Interface;
using Retail.Api.Customers.Repositories;
using Retail.Api.Customers.Service;
using Retail.Api.Customers.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
builder.Services.AddTransient<IDapperRepository, DapperRepository>();
builder.Services.AddTransient<IEntityUnitOfWork, EntityUnitOfWork>();
builder.Services.AddTransient<IDapperUnitOfWork, DapperUnitOfWork>();

builder.Services.AddTransient<ICustomerEntityRepository, CustomerEntityRepository>();
builder.Services.AddTransient<ICustomerDapperRepository, CustomerDapperRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();