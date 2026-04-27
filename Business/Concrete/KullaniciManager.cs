using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    internal class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public Kullanici GetByMail(string email)
        {
            return _kullaniciDal.Get(u => u.EPosta == email); 
        }

        public List<OperationClaim> GetClaims(Kullanici kullanici)
        {
            return new List<OperationClaim>();
        }
    }
}
