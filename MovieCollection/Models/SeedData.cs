using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MoviesDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<MoviesDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();

            }
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new EnterMovie
                    { 
                        
                        title = "The Blind Side",
                        note = "This is a good movie",
                        rating = "PG-13",
                        category = "Biographical",
                        year = 2009,
                        director = "John Lee Handcock",
                        edited = true

                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
