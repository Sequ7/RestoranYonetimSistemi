using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SegnaERPApi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRolTanimService _rolTanimService;
        private readonly IRolePermissionService _rolePermissionService;

        public RolesController(IRolTanimService rolTanimService, IRolePermissionService rolePermissionService)
        {
            _rolTanimService = rolTanimService;
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_rolTanimService.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var role = _rolTanimService.GetById(id);
            if (role is null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateRoleDto dto)
        {
            var role = new RolTanim { RolTanimAdi = dto.RolTanimAdi };
            _rolTanimService.Add(role);
            return Ok(role);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] CreateRoleDto dto)
        {
            var role = _rolTanimService.GetById(id);
            if (role is null)
            {
                return NotFound();
            }

            role.RolTanimAdi = dto.RolTanimAdi;
            _rolTanimService.Update(role);
            return Ok(role);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _rolTanimService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id:int}/permissions")]
        public IActionResult GetPermissions(int id)
        {
            return Ok(_rolePermissionService.GetRolePermissions(id));
        }

        [HttpPost("{id:int}/permissions")]
        public IActionResult AddPermission(int id, [FromBody] AssignPermissionDto dto)
        {
            _rolePermissionService.AddPermissionToRole(id, dto.OperationClaimId);
            return Ok();
        }

        [HttpDelete("{id:int}/permissions/{permissionId:int}")]
        public IActionResult RemovePermission(int id, int permissionId)
        {
            _rolePermissionService.RemovePermissionFromRole(id, permissionId);
            return NoContent();
        }
    }
}
