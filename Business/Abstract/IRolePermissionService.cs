using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IRolePermissionService
    {
        IList<OperationClaim> GetRolePermissions(int rolTanimId);
        void AddPermissionToRole(int rolTanimId, int operationClaimId);
        void RemovePermissionFromRole(int rolTanimId, int operationClaimId);
    }
}
