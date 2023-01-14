using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Endpoints.FeatureValue.ProductImage.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Delete : ControllerBase
    {
        private readonly IRepository _repository;

        public Delete(IRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("ProductImage/{id:int}")]
        public async Task<IActionResult> HandleAsync([FromRoute] int id)
        {
            Core.Entities.ProductImage request = new()
            {
                Id = id,
            };

            var result = await _repository.DeleteAsync(request);

            return result ? Accepted() : BadRequest();
        }
    }
}
