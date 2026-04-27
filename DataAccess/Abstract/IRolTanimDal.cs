using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRolTanimDal : IEntityRepository<RolTanim>
    {
        // Buraya gerekirse Role özel metodlar yazılabilir.
    }
}
