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
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanicilar");
                entity.HasKey(x => x.KullaniciID);
                entity.Property(x => x.KullaniciID).HasColumnName("KullaniciID");
                entity.Property(x => x.Ad).HasColumnName("Ad");
                entity.Property(x => x.Soyad).HasColumnName("Soyad");
                entity.Property(x => x.EPosta).HasColumnName("EPosta");
                entity.Property(x => x.KullaniciAdi).HasColumnName("KullaniciAdi");
                entity.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
                entity.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
                entity.Property(x => x.Aktif).HasColumnName("Aktif");
            });

            modelBuilder.Entity<RolTanim>(entity =>
            {
                entity.ToTable("RolTanimlari");
                entity.HasKey(x => x.RolTanimID);
                entity.Property(x => x.RolTanimID).HasColumnName("RolTanimID");
                entity.Property(x => x.RolTanimAdi).HasColumnName("RolTanimAdi");
            });

            modelBuilder.Entity<OperationClaim>(entity =>
            {
                entity.ToTable("OperationClaims");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.Name).HasColumnName("Name");
                entity.Property(x => x.Description).HasColumnName("Description");
            });

            modelBuilder.Entity<RolYetki>(entity =>
            {
                entity.ToTable("RolYetkileri");
                entity.HasKey(x => x.RolYetkiID);
                entity.Property(x => x.RolYetkiID).HasColumnName("RolYetkiID");
                entity.Property(x => x.RolTanimID).HasColumnName("RolTanimID");
                entity.Property(x => x.OperationClaimID).HasColumnName("OperationClaimID");
                entity.HasIndex(x => new { x.RolTanimID, x.OperationClaimID }).IsUnique();
            });

            modelBuilder.Entity<KullaniciRol>(entity =>
            {
                entity.ToTable("KullaniciRolleri");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.KullaniciID).HasColumnName("KullaniciID");
                entity.Property(x => x.RolTanimID).HasColumnName("RolTanimID");
                entity.HasIndex(x => new { x.KullaniciID, x.RolTanimID }).IsUnique();
            });

            modelBuilder.Entity<UserOperationClaim>(entity =>
            {
                entity.ToTable("UserOperationClaims");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("Id");
                entity.Property(x => x.KullaniciID).HasColumnName("KullaniciID");
                entity.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");
            });

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
