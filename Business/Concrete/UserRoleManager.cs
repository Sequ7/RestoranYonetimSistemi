using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IKullaniciDal _kullaniciDal;
        private readonly IKullaniciRolDal _kullaniciRolDal;
        private readonly IRolTanimDal _rolTanimDal;

        public UserRoleManager(IKullaniciDal kullaniciDal, IKullaniciRolDal kullaniciRolDal, IRolTanimDal rolTanimDal)
        {
            _kullaniciDal = kullaniciDal;
            _kullaniciRolDal = kullaniciRolDal;
            _rolTanimDal = rolTanimDal;
        }

        public IList<Kullanici> GetUsers() => _kullaniciDal.GetList();

        public IList<RolTanim> GetUserRoles(int kullaniciId)
        {
            var roleIds = _kullaniciRolDal.GetList(x => x.KullaniciID == kullaniciId)
                .Select(x => x.RolTanimID)
                .Distinct()
                .ToList();

            if (roleIds.Count == 0)
            {
                return new List<RolTanim>();
            }

            return _rolTanimDal.GetList(x => roleIds.Contains(x.RolTanimID));
        }

        public void AssignRole(int kullaniciId, int rolTanimId)
        {
            var exists = _kullaniciRolDal.Get(x => x.KullaniciID == kullaniciId && x.RolTanimID == rolTanimId);
            if (exists is not null)
            {
                return;
            }

            _kullaniciRolDal.Add(new KullaniciRol
            {
                KullaniciID = kullaniciId,
                RolTanimID = rolTanimId
            });
        }

        public void RemoveRole(int kullaniciId, int rolTanimId)
        {
            var existing = _kullaniciRolDal.Get(x => x.KullaniciID == kullaniciId && x.RolTanimID == rolTanimId);
            if (existing is null)
            {
                return;
            }

            _kullaniciRolDal.Delete(existing);
        }
    }
}
