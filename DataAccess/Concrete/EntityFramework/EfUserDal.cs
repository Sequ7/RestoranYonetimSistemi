using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SegnaContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new SegnaContext();

            var roleClaimsQuery =
                from kullanici in context.Kullanicilar
                join kullaniciRol in context.KullaniciRolleri on kullanici.KullaniciID equals kullaniciRol.KullaniciID
                join rolTanim in context.RolTanimlari on kullaniciRol.RolTanimID equals rolTanim.RolTanimID
                join rolYetki in context.RolYetkileri on rolTanim.RolTanimID equals rolYetki.RolTanimID
                join operationClaim in context.OperationClaims on rolYetki.OperationClaimID equals operationClaim.Id
                where kullanici.KullaniciID == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name,
                    Description = operationClaim.Description
                };

            var directClaimsQuery =
                from userOperationClaim in context.UserOperationClaims
                join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                where userOperationClaim.KullaniciID == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name,
                    Description = operationClaim.Description
                };

            return roleClaimsQuery
                .Union(directClaimsQuery)
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();
        }
    }
}
