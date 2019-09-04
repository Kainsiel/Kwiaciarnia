using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Data.ApplicationDbContext>>()))
            {
                if (context.Kwiat.Any())
                {
                    return;   // DB has been seeded
                }

                context.Kwiat.AddRange(
                    new Kwiat
                    {
                        Nazwa = "Roza",
                        Price = 7.99M
                    },
                    
                    new Kwiat
                    {
                        Nazwa = "Stokrotka",
                        Price = 7.99M
                    }
                );
                context.SaveChanges();

            }

        }
    }
}
