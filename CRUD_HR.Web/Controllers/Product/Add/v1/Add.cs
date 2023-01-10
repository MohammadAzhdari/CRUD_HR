using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Controllers.Product.Add.v1
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

        [HttpPost("Product")]
        public async Task<IActionResult> HandleAsync([FromBody] AddProductRequest input)
        {
            Core.Entities.Product request = new()
            {
                Name = input.Name,
                CategoryId = input.CategoryId,
                CodeNumber = input.CodeNumber,
                Description = input.Description,
                IsActive = input.IsActive,
            };

            var result = await _repository.AddAsync(request);

            AddProductResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
            };

            return Ok(response);
        }
    }
}
