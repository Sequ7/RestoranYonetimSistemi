using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRolTanimService
    {
        IList<RolTanim> GetAll();
        RolTanim? GetById(int id);
        void Add(RolTanim rolTanim);
        void Update(RolTanim rolTanim);
        void Delete(int id);
    }
}
