using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace SegnaERPApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UsersController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRoleService.GetUsers());
        }

        [HttpGet("{id:int}/roles")]
        public IActionResult GetRoles(int id)
        {
            return Ok(_userRoleService.GetUserRoles(id));
        }

        [HttpPost("{id:int}/roles")]
        public IActionResult AddRole(int id, [FromBody] AssignRoleDto dto)
        {
            _userRoleService.AssignRole(id, dto.RolTanimID);
            return Ok();
        }

        [HttpDelete("{id:int}/roles/{roleId:int}")]
        public IActionResult RemoveRole(int id, int roleId)
        {
            _userRoleService.RemoveRole(id, roleId);
            return NoContent();
        }
    }
}
