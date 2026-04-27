using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class AssignPermissionDto : IDto
    {
        public int OperationClaimId { get; set; }
    }
}
