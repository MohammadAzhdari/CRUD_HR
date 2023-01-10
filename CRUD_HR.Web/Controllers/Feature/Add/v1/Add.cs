using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Controllers.Feature.Add.v1
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

        [HttpPost("Feature")]
        public async Task<IActionResult> HandleAsync([FromBody] AddFeatureRequest input)
        {
            ProductCategoryFeature request = new()
            {
                Name = input.Name,
                TypeId = input.TypeId,
                CategoryId = input.CategoryId,
            };

            var result = await _repository.AddAsync(request);

            AddFeatureResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
            };

            return Ok(response);
        }
    }
}
