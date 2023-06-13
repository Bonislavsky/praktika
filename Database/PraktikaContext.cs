using Microsoft.EntityFrameworkCore;
using praktika.Domain;

namespace praktika.Database
{
    public class PraktikaContext : DbContext
    {
        public PraktikaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(t =>
            {
                t.HasKey(k => k.Id);

                t.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                t.Property(p => p.Name)
                    .IsRequired();

                t.HasData(
                        new Area() { Id = 1, Name = "Голосіївський" },
                        new Area() { Id = 2, Name = "Дарницький" },
                        new Area() { Id = 3, Name = "Деснянський" },
                        new Area() { Id = 4, Name = "Дніпровський" },
                        new Area() { Id = 5, Name = "Печерський" },
                        new Area() { Id = 6, Name = "Оболонський" },
                        new Area() { Id = 7, Name = "Подільський" },
                        new Area() { Id = 8, Name = "Солом'янський" },
                        new Area() { Id = 9, Name = "Святошинський" },
                        new Area() { Id = 10, Name = "Шевченкивський" });
            });

        }
    }
}
