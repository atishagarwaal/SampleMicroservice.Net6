//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable CA1852 // Seal internal types

using Microsoft.EntityFrameworkCore;
using Retail.Api.Customers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore CA1852 // Seal internal types