using Magi.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }//then navigate to tools => nuget package manager=> type in console add-migration AddVillaTable to update migration
        public DbSet<Villa> Villas { get; set; } //that will be the name of the table=> then to apply these migrations run the command update-database
        public DbSet<VillaNumber> VillaNumbers { get; set; } //second table
        public DbSet<LocalUser> users { get; set; } //second table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name="royal villa",
                    Details="i like this villa",
                    ImageUrl= "http://dotnetmastery.com/bluevillaimages/villa1.jpg",         
                    Occupancy=5,
                    Rate = 200,
                    Sqft =550,
                    Amenity="",
                    CreatedDate= DateTime.Now
                },
                //new Villa()
                //{
                //    Id = 2,
                //    Name = "Premium Pool Villa",
                //    Details = "here is the best villa",
                //    ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa2.jpg",
                //    Occupancy = 4,
                //    Rate = 300,
                //    Sqft = 552,
                //    Amenity = "",
                //    CreatedDate= DateTime.Now
                //},
				new Villa()
				{
					Id = 3,
					Name = "Luxury Pool Villa",
					Details = "just woow",
					ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa3.jpg",
					Occupancy = 4,
					Rate = 300,
					Sqft = 552,
					Amenity = "",
					CreatedDate = DateTime.Now
				}

				//new Villa()
				//{
				//	Id = 4,
				//	Name = "Diamand Villa",
				//	Details = "oh",
				//	ImageUrl = "http://dotnetmastery.com/bluevillaimages/villa4.jpg",
				//	Occupancy = 4,
				//	Rate = 300,
				//	Sqft = 552,
				//	Amenity = "",
				//	CreatedDate = DateTime.Now
				//}
				);
        }
    }
}
