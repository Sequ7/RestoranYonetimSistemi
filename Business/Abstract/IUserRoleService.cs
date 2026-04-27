using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
        IList<Kullanici> GetUsers();
        IList<RolTanim> GetUserRoles(int kullaniciId);
        void AssignRole(int kullaniciId, int rolTanimId);
        void RemoveRole(int kullaniciId, int rolTanimId);
    }
}
