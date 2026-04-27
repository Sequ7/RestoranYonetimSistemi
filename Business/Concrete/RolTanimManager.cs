using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RolTanimManager : IRolTanimService
    {
        private readonly IRolTanimDal _rolTanimDal;

        public RolTanimManager(IRolTanimDal rolTanimDal)
        {
            _rolTanimDal = rolTanimDal;
        }

        public IList<RolTanim> GetAll() => _rolTanimDal.GetList();

        public RolTanim? GetById(int id) => _rolTanimDal.Get(x => x.RolTanimID == id);

        public void Add(RolTanim rolTanim) => _rolTanimDal.Add(rolTanim);

        public void Update(RolTanim rolTanim) => _rolTanimDal.Update(rolTanim);

        public void Delete(int id)
        {
            var entity = _rolTanimDal.Get(x => x.RolTanimID == id);
            if (entity is null)
            {
                return;
            }

            _rolTanimDal.Delete(entity);
        }
    }
}
