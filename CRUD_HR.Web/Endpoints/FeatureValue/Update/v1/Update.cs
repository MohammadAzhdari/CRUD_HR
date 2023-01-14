using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Endpoints.FeatureValue.Update.v1
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

        [HttpPut("FeatureValue/{id:int}")]
        public async Task<IActionResult> HandleAsync([FromRoute] int id, [FromBody] UpdateFeatureValueRequest input)
        {
            ProductCategoryFeatureValue request = new()
            {
                Id = id,
                FeatureId = input.FeatureId,
                value = input.Value
            };

            var result = await _repository.UpdateAsync(request);

            return result ? Accepted() : BadRequest();
        }
    }
}
