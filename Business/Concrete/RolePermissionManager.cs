using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IRolYetkiDal _rolYetkiDal;
        private readonly IOperationClaimDal _operationClaimDal;

        public RolePermissionManager(IRolYetkiDal rolYetkiDal, IOperationClaimDal operationClaimDal)
        {
            _rolYetkiDal = rolYetkiDal;
            _operationClaimDal = operationClaimDal;
        }

        public IList<OperationClaim> GetRolePermissions(int rolTanimId)
        {
            var permissionIds = _rolYetkiDal.GetList(x => x.RolTanimID == rolTanimId)
                .Select(x => x.OperationClaimID)
                .Distinct()
                .ToList();

            if (permissionIds.Count == 0)
            {
                return new List<OperationClaim>();
            }

            return _operationClaimDal.GetList(x => permissionIds.Contains(x.Id));
        }

        public void AddPermissionToRole(int rolTanimId, int operationClaimId)
        {
            var exists = _rolYetkiDal.Get(x => x.RolTanimID == rolTanimId && x.OperationClaimID == operationClaimId);
            if (exists is not null)
            {
                return;
            }

            _rolYetkiDal.Add(new RolYetki
            {
                RolTanimID = rolTanimId,
                OperationClaimID = operationClaimId
            });
        }

        public void RemovePermissionFromRole(int rolTanimId, int operationClaimId)
        {
            var existing = _rolYetkiDal.Get(x => x.RolTanimID == rolTanimId && x.OperationClaimID == operationClaimId);
            if (existing is null)
            {
                return;
            }

            _rolYetkiDal.Delete(existing);
        }
    }
}
