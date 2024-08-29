using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }//then navigate to tools => nuget package manager=> type in console add-migration AddVillaTable
        public DbSet<Villa> Villas { get; set; } //that will be the name of the table=> then to apply these migrations run the command update-database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name="royal villa",
                    Details="hi",
                    ImageUrl= "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",         
                    Occupancy=5,
                    Rate = 200,
                    Sqft =550,
                    Amenity="",
                    CreatedDate= DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "royal2 villa",
                    Details = "hihi",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                    Occupancy = 5,
                    Rate = 202,
                    Sqft = 552,
                    Amenity = "",
                    CreatedDate= DateTime.Now
                }
                );
        }
    }
}
