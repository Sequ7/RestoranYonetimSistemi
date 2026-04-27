using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    [Table("UserOperationClaims")]
    public class UserOperationClaim : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("KullaniciID")]
        public int KullaniciID { get; set; }

        [Column("OperationClaimId")]
        public int OperationClaimId { get; set; }
    }
}
