using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using CRUD_HR.Core.Utility;
using CRUD_HR.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_HR.Web.Endpoints.FeatureValue.Get.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Get : ControllerBase
    {
        private readonly IProductCategoryFeatureValueRepository _productCategoryFeatureValueRepository;

        public Get(IProductCategoryFeatureValueRepository productCategoryFeatureValueRepository)
        {
            _productCategoryFeatureValueRepository = productCategoryFeatureValueRepository;
        }

        [HttpGet("FeatureValue/{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _productCategoryFeatureValueRepository.GetAsync(id);

            if (result is null)
                return BadRequest();

            GetFeatureValueResponse response = new()
            {
                Id = result.Id,
                value = result.value,
                FeatureId = result.FeatureId,
                FeatureName = result.ProductCategoryFeature.Name
            };

            return Ok(response);
        }

        [HttpGet("FeatureValue")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productCategoryFeatureValueRepository.ListAsync();

            var response = (from x in result
                            select new GetFeatureValueResponse
                            {
                                Id = x.Id,
                                value = x.value,
                                FeatureId = x.FeatureId,
                                FeatureName = x.ProductCategoryFeature.Name
                            }).ToList();

            return Ok(response);
        }
    }
}
