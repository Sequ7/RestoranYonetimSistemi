using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class CreateRoleDto : IDto
    {
        public string RolTanimAdi { get; set; } = string.Empty;
    }
}
