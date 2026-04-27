using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IList<OperationClaim> GetAll() => _operationClaimDal.GetList();

        public OperationClaim? GetById(int id) => _operationClaimDal.Get(x => x.Id == id);

        public void Add(OperationClaim operationClaim) => _operationClaimDal.Add(operationClaim);

        public void Update(OperationClaim operationClaim) => _operationClaimDal.Update(operationClaim);

        public void Delete(int id)
        {
            var entity = _operationClaimDal.Get(x => x.Id == id);
            if (entity is null)
            {
                return;
            }

            _operationClaimDal.Delete(entity);
        }
    }
}
