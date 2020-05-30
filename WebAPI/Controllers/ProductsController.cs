using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _prodoctService;

        public ProductsController(IProductService productService)
        {
            _prodoctService = productService;
        }

        [HttpGet(template: "getall")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
            var result = _prodoctService.GetList();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "getlistbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _prodoctService.GetListByCategory(categoryId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _prodoctService.GetbyId(productId);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Product product)
        {
            var result = _prodoctService.Add(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Product product)
        {
            var result = _prodoctService.Update(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Product product)
        {
            var result = _prodoctService.Delete(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}