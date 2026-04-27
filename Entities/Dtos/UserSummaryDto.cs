using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserSummaryDto : IDto
    {
        public int KullaniciID { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string EPosta { get; set; } = string.Empty;
        public string KullaniciAdi { get; set; } = string.Empty;
        public bool Aktif { get; set; }
    }
}
