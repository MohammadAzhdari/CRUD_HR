using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Endpoints.Product.Update.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Update : ControllerBase
    {
        private readonly IRepository _repository;

        public Update(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("Product/{id:int}")]
        public async Task<IActionResult> HandleAsync([FromRoute] int id, [FromBody] UpdateProductRequest input)
        {
            Core.Entities.Product request = new()
            {
                Id = id,
                Name = input.Name,
                Description = input.Description,
                CodeNumber = input.CodeNumber,
                IsActive = input.IsActive,
                CategoryId = input.CategoryId,  
            };

            var result = await _repository.UpdateAsync(request);

            return result ? Accepted() : BadRequest();
        }
    }
}
