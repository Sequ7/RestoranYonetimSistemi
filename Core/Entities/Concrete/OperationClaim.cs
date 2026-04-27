using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    [Table("OperationClaims")]
    public class OperationClaim : IEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        public string? Description { get; set; }
    }
}
