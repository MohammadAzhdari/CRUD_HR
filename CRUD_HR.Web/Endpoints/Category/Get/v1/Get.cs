using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAsync([FromRoute]int id)
        {
            var result = await _repository.GetAsync<ProductCategory>(id);

            return Ok(result);
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetAllAsync()
        {
            //var result = await _repository.GetAsync<ProductCategory>();

           // return Ok(result);
        }
    }
}
