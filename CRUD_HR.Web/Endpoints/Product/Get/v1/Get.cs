using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using CRUD_HR.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_HR.Web.Endpoints.Product.Get.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Get : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public Get(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("Product/{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _productRepository.GetAsync(id);

            if (result is null)
                return BadRequest();

            var images = (from x in result.Images
                          select new ProductImage
                          {
                              ImagePath = x.Path,
                              IsBanner = x.IsBanner,
                          }).ToList();

            GetProductResponse response = new()
            {
                Id = result.Id,
                Name = result.Name,
                CategoryId = result.CategoryId,
                Category = result.Category.Name,
                CodeNumber = result.CodeNumber,
                Description = result.Description,
                IsActive = result.IsActive,
                Images = images
            };

            return Ok(response);
        }

        [HttpGet("Product")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productRepository.ListAsync();

            var response = (from x in result
                            select new GetProductResponse
                            {
                                Id = x.Id,
                                Name = x.Name,
                                CategoryId = x.CategoryId,
                                Category = x.Category.Name,
                                CodeNumber = x.CodeNumber,
                                Description = x.Description,
                                IsActive = x.IsActive,
                                Images = (from a in x.Images
                                          select new ProductImage
                                          {
                                              ImagePath = a.Path,
                                              IsBanner = a.IsBanner,
                                          }).ToList()
                            }).ToList();

            return Ok(response);
        }
    }
}
