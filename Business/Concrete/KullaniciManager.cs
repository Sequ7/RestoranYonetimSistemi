using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        private readonly IKullaniciDal _kullaniciDal;
        private readonly IRolYetkiDal _rolYetkiDal;
        private readonly IKullaniciRolDal _kullaniciRolDal;
        private readonly IOperationClaimDal _operationClaimDal;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public KullaniciManager(
            IKullaniciDal kullaniciDal,
            IRolYetkiDal rolYetkiDal,
            IKullaniciRolDal kullaniciRolDal,
            IOperationClaimDal operationClaimDal,
            IUserOperationClaimDal userOperationClaimDal)
        {
            _kullaniciDal = kullaniciDal;
            _rolYetkiDal = rolYetkiDal;
            _kullaniciRolDal = kullaniciRolDal;
            _operationClaimDal = operationClaimDal;
            _userOperationClaimDal = userOperationClaimDal;
        }

        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public IList<Kullanici> GetAll() => _kullaniciDal.GetList();

        public Kullanici? GetByMail(string email)
        {
            return _kullaniciDal.Get(u => u.EPosta == email);
        }

        public Kullanici? GetById(int id)
        {
            return _kullaniciDal.Get(u => u.KullaniciID == id);
        }

        public List<OperationClaim> GetClaims(Kullanici kullanici)
        {
            var roleIds = _kullaniciRolDal.GetList(x => x.KullaniciID == kullanici.KullaniciID)
                .Select(x => x.RolTanimID)
                .Distinct()
                .ToList();

            var rolePermissionIds = roleIds.Count == 0
                ? new List<int>()
                : _rolYetkiDal.GetList(x => roleIds.Contains(x.RolTanimID))
                    .Select(x => x.OperationClaimID)
                    .Distinct()
                    .ToList();

            var directPermissionIds = _userOperationClaimDal.GetList(x => x.KullaniciID == kullanici.KullaniciID)
                .Select(x => x.OperationClaimId)
                .Distinct()
                .ToList();

            var allPermissionIds = rolePermissionIds
                .Union(directPermissionIds)
                .Distinct()
                .ToList();

            if (allPermissionIds.Count == 0)
            {
                return new List<OperationClaim>();
            }

            return _operationClaimDal.GetList(x => allPermissionIds.Contains(x.Id)).ToList();
        }
    }
}
