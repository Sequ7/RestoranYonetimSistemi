using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class RolYetki : IEntity
    {
        [Key]
        public int RolYetkiID { get; set; }
        public int RolTanimID { get; set; }
        public int OperationClaimID { get; set; }
    }
}
