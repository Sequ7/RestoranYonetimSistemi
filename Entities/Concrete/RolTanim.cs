using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class RolTanim : IEntity
    {
        [Key]
        public int RolTanimID { get; set; }
        public string RolTanimAdi { get; set; } = string.Empty;
    }
}
