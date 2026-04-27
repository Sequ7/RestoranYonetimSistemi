using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("KullaniciRolleri")]
    public class KullaniciRol : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("KullaniciID")]
        public int KullaniciID { get; set; }

        [Column("RolTanimID")]
        public int RolTanimID { get; set; }
    }
}
