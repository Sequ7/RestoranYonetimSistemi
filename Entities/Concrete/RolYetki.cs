using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("RolYetkileri")]
    public class RolYetki : IEntity
    {
        [Key]
        [Column("RolYetkiID")]
        public int RolYetkiID { get; set; }

        [Column("RolTanimID")]
        public int RolTanimID { get; set; }

        [Column("OperationClaimID")]
        public int OperationClaimID { get; set; }
    }
}
