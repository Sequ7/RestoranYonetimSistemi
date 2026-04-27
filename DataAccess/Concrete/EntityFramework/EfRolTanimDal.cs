using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRolTanimDal : EfEntityRepositoryBase<RolTanim, SegnaContext>, IRolTanimDal
    {
        // Listeleme, Ekleme, Silme metodları hazır gelir.
    }
}
