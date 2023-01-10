using CRUD_HR.Core.Entities;
using CRUD_HR.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Environment = Microsoft.AspNetCore.Hosting;

namespace CRUD_HR.Web.Controllers.ProductImage.Add.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Add : ControllerBase
    {
        private readonly IRepository _repository;
        private Environment.IHostingEnvironment _environment;

        public Add(
            IRepository repository,
            Environment.IHostingEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        [HttpPost("ProductImage")]
        public async Task<IActionResult> HandleAsync([FromForm] AddProductImageRequest input)
        {
            string serverPath = Path.Combine(_environment.WebRootPath, "Images");
            string fileName = Guid.NewGuid().ToString() + "." + input.File.FileName.Split('.').Last();
            string filePath = Path.Combine(serverPath, fileName);

            bool isOk = false;
            if (input.File.Length > 0)
            {
                try
                {
                    using Stream fileStream = new FileStream(filePath, FileMode.Create);
                    await input.File.CopyToAsync(fileStream);
                    isOk = true;
                }
                catch (Exception ex)
                {

                }
            }

            if (!isOk)
                return StatusCode(500);

            Core.Entities.ProductImage image = new()
            {
                IsBanner = input.IsBanner,
                ProductId = input.ProductId,
                Path = fileName,
            };

            var result = await _repository.AddAsync(image);

            return Ok(result);
        }
    }
}
