using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ruleta.Interfaces;
using Ruleta.Models;

namespace Ruleta.Context
{
    public partial class RouletteContext : DbContext
    {
        public IDBManager Manager;
        public RouletteContext(IDBManager dBManager)
        {
            Manager = dBManager;
        }

        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BetsRoulettesUser> BetsRoulettesUsers { get; set; }
        public virtual DbSet<Roulette> Roulettes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Manager.BuildConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<BetsRoulettesUser>(entity =>
            {
                entity.HasKey(e => e.IdBetRouletteUser)
                    .HasName("PK__BetsRoul__C7EF08F5B733AE23");

                entity.HasOne(d => d.Roulette)
                    .WithMany(p => p.BetsRoulettesUsers)
                    .HasForeignKey(d => d.RouletteId)
                    .HasConstraintName("fk_Roulette");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BetsRoulettesUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_User");
            });

            modelBuilder.Entity<Roulette>(entity =>
            {
                entity.HasKey(e => e.IdRoulette)
                    .HasName("PK__Roulette__506300F7FE385D2B");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C92638571A2FBE");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
