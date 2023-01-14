using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Endpoints.Category.Add.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Add : ControllerBase
    {
        private readonly IRepository _repository;

        public Add(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Category")]
        public async Task<IActionResult> HandleAsync([FromBody] AddCategoryRequest input)
        {
            ProductCategory request = new()
            {
                Name = input.Name,
            };

            var result = await _repository.AddAsync(request);

            AddCategoryResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
            };

            return Ok(response);
        }
    }
}
