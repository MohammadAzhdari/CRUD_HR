using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using CRUD_HR.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_HR.Web.Endpoints.Category.Get.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Get : ControllerBase
    {
        private readonly IRepository _repository;

        public Get(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Category/{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _repository.GetAsync<ProductCategory>(id);

            if (result is null)
                return BadRequest();

            GetCategoryResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
            };

            return Ok(response);
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.ListAsync<ProductCategory>();

            var response = (from x in result
                            select new GetCategoryResponse
                            {
                                Id = x.Id,
                                Name = x.Name,
                            }).ToList();

            return Ok(response);
        }
    }
}
