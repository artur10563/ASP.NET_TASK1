using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_TASK1.Models.DirModels
{
    public class DirsContext : DbContext
    {
        public DbSet<Dir> Dirs { get; set; }
        public DbSet<DirRelation> DirRelations { get; set; }

        public DirsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dir>()
    .ToTable("Dirs");

            modelBuilder.Entity<Dir>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Dir>()
                .HasData(
                    new Dir { Id = 1, Name = "Creating Digital Images" },
                    new Dir { Id = 2, Name = "Resources" },
                    new Dir { Id = 3, Name = "Primary Sources" },
                    new Dir { Id = 4, Name = "Secondary Sources" },
                    new Dir { Id = 5, Name = "Evidence" },
                    new Dir { Id = 6, Name = "Graphic Products" },
                    new Dir { Id = 7, Name = "Process" },
                    new Dir { Id = 8, Name = "Final Product" }
                );

            modelBuilder.Entity<DirRelation>()
                .ToTable("DirRelations");

            modelBuilder.Entity<DirRelation>()
                .HasOne(d => d.Parent)
                .WithMany()
                .HasForeignKey(d => d.Id_Parent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DirRelation>()
                .HasOne(d => d.Child)
                .WithMany()
                .HasForeignKey(d => d.Id_Child)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DirRelation>()
                .HasData(
                    new DirRelation { Id = 1, Id_Parent = 1, Id_Child = 2 },
                    new DirRelation { Id = 2, Id_Parent = 1, Id_Child = 5 },
                    new DirRelation { Id = 3, Id_Parent = 1, Id_Child = 6 },
                    new DirRelation { Id = 4, Id_Parent = 2, Id_Child = 3 },
                    new DirRelation { Id = 5, Id_Parent = 2, Id_Child = 4 },
                    new DirRelation { Id = 6, Id_Parent = 6, Id_Child = 7 },
                    new DirRelation { Id = 7, Id_Parent = 6, Id_Child = 8 }
                );                    
        }


    }
}
