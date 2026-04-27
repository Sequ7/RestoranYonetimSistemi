using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SegnaERPApi.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PermissionsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public PermissionsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_operationClaimService.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreatePermissionDto dto)
        {
            var entity = new OperationClaim
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _operationClaimService.Add(entity);
            return Ok(entity);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] CreatePermissionDto dto)
        {
            var entity = _operationClaimService.GetById(id);
            if (entity is null)
            {
                return NotFound();
            }

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            _operationClaimService.Update(entity);
            return Ok(entity);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _operationClaimService.Delete(id);
            return NoContent();
        }
    }
}
