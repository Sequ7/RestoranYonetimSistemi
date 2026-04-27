using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Kullanicilar")]
    public class Kullanici : IEntity
    {
        [Column("KullaniciID")]
        public int KullaniciID { get; set; }

        [Column("Ad")]
        public string Ad { get; set; } = string.Empty;

        [Column("Soyad")]
        public string Soyad { get; set; } = string.Empty;

        [Column("EPosta")]
        public string EPosta { get; set; } = string.Empty;

        [Column("KullaniciAdi")]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Column("PasswordSalt")]
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        [Column("PasswordHash")]
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

        [Column("Aktif")]
        public bool Aktif { get; set; }
    }
}
