using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SegnaERPApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(Roles = "admin")]
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
            var users = _userRoleService.GetUsers()
                .Select(x => new UserSummaryDto
                {
                    KullaniciID = x.KullaniciID,
                    Ad = x.Ad,
                    Soyad = x.Soyad,
                    EPosta = x.EPosta,
                    KullaniciAdi = x.KullaniciAdi,
                    Aktif = x.Aktif
                })
                .ToList();

            return Ok(users);
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
