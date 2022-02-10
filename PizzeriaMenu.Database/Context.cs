using Microsoft.EntityFrameworkCore;
using PizzeriaMenu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMenu.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public DbSet<Ingredient> Ingredients => Set<Ingredient>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Ingredient>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id)
                .ValueGeneratedOnAdd();
                b.HasOne(x => x.Pizza)
                     .WithMany(u => u.Ingredients)
                     .HasForeignKey(x => x.PizzaId);
            });

        }
    }
}
