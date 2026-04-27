using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IList<OperationClaim> GetAll();
        OperationClaim? GetById(int id);
        void Add(OperationClaim operationClaim);
        void Update(OperationClaim operationClaim);
        void Delete(int id);
    }
}
