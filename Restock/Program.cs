using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Restock.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallServicesInAssembly(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//    
// }
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        var adminRole = new IdentityRole { Name = "Admin" };
        await roleManager.CreateAsync(adminRole);
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        var userRole = new IdentityRole { Name = "User" };
        await roleManager.CreateAsync(userRole);
    }
}
app.Run();