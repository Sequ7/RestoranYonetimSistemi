using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("RolTanimlari")]
    public class RolTanim : IEntity
    {
        [Key]
        [Column("RolTanimID")]
        public int RolTanimID { get; set; }

        [Column("RolTanimAdi")]
        public string RolTanimAdi { get; set; } = string.Empty;
    }
}
