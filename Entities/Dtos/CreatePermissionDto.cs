using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class CreatePermissionDto : IDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
