using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class SegnaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-J77AU3J\SQLEXPRESS;Database=RestoranMasterDB;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<RolTanim> RolTanimlari { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RolYetki> RolYetkileri { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<KullaniciRol> KullaniciRolleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar").HasKey(k => k.KullaniciID);
            modelBuilder.Entity<RolTanim>().ToTable("RolTanimlari").HasKey(r => r.RolTanimID);
            modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims").HasKey(oc => oc.Id);
            modelBuilder.Entity<RolYetki>().ToTable("RolYetkileri").HasKey(ry => ry.RolYetkiID);
            modelBuilder.Entity<UserOperationClaim>().ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);
            modelBuilder.Entity<KullaniciRol>().ToTable("KullaniciRolleri").HasKey(kr => kr.ID);

            modelBuilder.Entity<RolYetki>()
                .HasIndex(x => new { x.RolTanimID, x.OperationClaimID })
                .IsUnique();

            modelBuilder.Entity<KullaniciRol>()
                .HasIndex(x => new { x.KullaniciID, x.RolTanimID })
                .IsUnique();

            modelBuilder.Entity<KullaniciRol>()
                .HasOne<Kullanici>()
                .WithMany()
                .HasForeignKey(x => x.KullaniciID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KullaniciRol>()
                .HasOne<RolTanim>()
                .WithMany()
                .HasForeignKey(x => x.RolTanimID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolYetki>()
                .HasOne<RolTanim>()
                .WithMany()
                .HasForeignKey(x => x.RolTanimID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolYetki>()
                .HasOne<OperationClaim>()
                .WithMany()
                .HasForeignKey(x => x.OperationClaimID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne<Kullanici>()
                .WithMany()
                .HasForeignKey(x => x.KullaniciID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne<OperationClaim>()
                .WithMany()
                .HasForeignKey(x => x.OperationClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
