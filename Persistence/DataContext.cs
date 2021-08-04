using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }


        public DbSet<Channel> Channel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder
                .Entity<Channel>()
                .HasData(
                    new Channel()
                    {
                        Id=Guid.NewGuid(),
                        Name="Net Core",
                        Description="Canal dedicado a net core"
                    },
                    new Channel()
                    {
                        Id = Guid.NewGuid(),
                        Name = "ReactJs",
                        Description = "Canal dedicado a ReactJs"
                    }
                );
        }
    }
}
