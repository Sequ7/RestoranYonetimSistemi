using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKullaniciService
    {
        List<OperationClaim> GetClaims(Kullanici kullanici);
        void Add(Kullanici kullanici);
        Kullanici? GetByMail(string email);
        Kullanici? GetById(int id);
        IList<Kullanici> GetAll();
    }
}
