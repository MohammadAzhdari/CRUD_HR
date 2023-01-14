using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Endpoints.Category.Update.v1
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

        [HttpPut("Category/{id:int}")]
        public async Task<IActionResult> HandleAsync([FromRoute] int id, [FromBody] UpdateCategoryRequest input)
        {
            ProductCategory request = new()
            {
                Id = id,
                Name = input.Name,
            };

            var result = await _repository.UpdateAsync(request);

            return result ? Accepted() : BadRequest();
        }
    }
}
