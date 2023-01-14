using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using CRUD_HR.Core.Utility;
using CRUD_HR.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_HR.Web.Endpoints.Feature.Get.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Get : ControllerBase
    {
        private readonly IProductCategoryFeatureRepository _productCategoryFeatureRepository;

        public Get(IProductCategoryFeatureRepository productCategoryFeatureRepository)
        {
            _productCategoryFeatureRepository = productCategoryFeatureRepository;
        }

        [HttpGet("Feature/{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _productCategoryFeatureRepository.GetAsync(id);

            if (result is null)
                return BadRequest();

            GetFeatureResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
                CategoryId = result.CategoryId,
                TypeId = result.TypeId,
                Category = result.ProductCategory.Name,
                Type = result.ProductCategoryFeatureType.Name
            };

            return Ok(response);
        }

        [HttpGet("Feature")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productCategoryFeatureRepository.ListAsync();

            var response = (from x in result
                            select new GetFeatureResponse
                            {
                                Id = x.Id,
                                Name = x.Name,
                                CategoryId = x.CategoryId,
                                TypeId = x.TypeId,
                                Category = x.ProductCategory.Name,
                                Type = x.ProductCategoryFeatureType.Name
                            }).ToList();

            return Ok(response);
        }
    }
}
