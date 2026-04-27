using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class KullaniciRol : IEntity
    {
        public int KullaniciRolID { get; set; }
        public int KullaniciID { get; set; }
        public int RolTanimID { get; set; }
    }
}
