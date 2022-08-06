<!-- Instaloni vetem njehere framework EF  -->
dotnet tool install --global dotnet-ef

<!-- Kontrolloni instalimin -->
dotnet ef

<!-- Per cdo projekt te ri instaloni paketat  -->
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3

<!-- Krijoni modelin qe duhet per databazen -->
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Monsters.Models;
public class Monster
{
    [Key]
    <!-- Kujdes ID -->
    public int MonsterId { get; set; }
    public string Name { get; set; } 
    public int Height { get; set; }
    public string Description { get; set; }

<!-- datetime leri sic jane -->
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}







<!-- Tek models krijoni filen MyContext.cs dhe vendosni brenda -->
#pragma warning disable CS8618
/* 
Disabled Warning: "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable."
We can disable this safely because we know the framework will assign non-null values when it constructs this class for us.
*/
using Microsoft.EntityFrameworkCore;
<!-- kujdes namespace -->
namespace Monsters.Models;
// the MyContext class representing a session with our MySQL database, allowing us to query for or save data
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    // the "Monsters" table name will come from the DbSet property name

<!-- Ndryshoni Monster me emrin e modelit tuaj -->
    public DbSet<Monster> Monsters { get; set; } 
}




<!-- rregulloni appsettings.json -->
<!-- KUJDES -->
<!-- KUJDES -->
<!-- KUJDES -->
<!-- EMRIN E DB TE JETE UNIQUE, userid == root, passowrd == root ose sic e keni vendos kur e keni instaluar flm -->
<!-- KUJDES -->
<!-- KUJDES -->
<!-- KUJDES -->
<!-- mos harroni presjen -->

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings":
    {
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=Flogert@23;database=productdb;"
    }
}


<!-- shtojeni tek program.cs kodin me poshte dhe mos harroni pikpresjen ;  tek rrjeshti var builder -->

// Additional libraries
using Microsoft.EntityFrameworkCore;
using ProjectName.Models;
// Creates builder (also part of boilerplate code for web apps)
var builder = WebApplication.CreateBuilder(args)
//  Creates the db connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Adds database connection - must be before app.Build();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

<!-- beni migrimet -->
    dotnet ef migrations add FirstMigration
dotnet ef database update








