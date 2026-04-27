using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    using Entities.Concrete;
    using Microsoft.EntityFrameworkCore;

    namespace DataAccess.Concrete.EntityFramework.Contexts
    {
        public class SegnaContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Bağlantı dizen doğru, TrustServerCertificate eklenmiş haliyle korunuyor
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-J77AU3J\SQLEXPRESS;Database=RestoranMasterDB;Trusted_Connection=true;TrustServerCertificate=True;");
            }

            // Tablo tanımları (DbSet)
            public DbSet<Kullanici> Kullanicilar { get; set; }
            public DbSet<RolTanim> RolTanimlari { get; set; }
            public DbSet<OperationClaim> OperationClaims { get; set; } // Çakışmayı önlemek için tam yol
            public DbSet<OperationClaim> RolYetkileri { get; set; }
            public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");
                modelBuilder.Entity<RolTanim>().ToTable("RolTanimlari");
                modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims");
                modelBuilder.Entity<OperationClaim>().ToTable("RolYetkileri");
                modelBuilder.Entity<UserOperationClaim>().ToTable("UserOperationClaims");

                modelBuilder.Entity<Kullanici>().HasKey(k => k.KullaniciID);
                modelBuilder.Entity<RolTanim>().HasKey(r => r.RolTanimID);
                modelBuilder.Entity<Core.Entities.Concrete.OperationClaim>().HasKey(oc => oc.Id);
            }
        }
    }
}
