using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_HR.Web.Controllers.FeatureValue.Add.v1
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

        [HttpPost("FeatureValue")]
        public async Task<IActionResult> HandleAsync([FromBody] AddFeatureValueRequest input)
        {
            ProductCategoryFeatureValue request = new()
            {
                value = input.Value,
                FeatureId = input.FeatureId
            };

            var result = await _repository.AddAsync(request);

            return Ok(result);
        }
    }
}
