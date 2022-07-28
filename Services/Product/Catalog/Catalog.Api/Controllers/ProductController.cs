using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Catalog.Api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository?? throw new ArgumentNullException(nameof(productRepository));
            _logger=logger?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet("{id}",Name ="GetProduct")]
        [ProducesResponseType(typeof(Game), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Game), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Game>> GetProduct(long id)
        {
            var product = await _productRepository.GetGame(id);
            if (product==null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound(product);
            }
            return Ok(product);

        }
        [Route("[action]/{ordering}/{SearchKey}/{catid}/{pagesize}/{page}", Name = "GetProducts")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductListResult), (int)HttpStatusCode.OK)]
        public ActionResult<ProductListResult> GetProducts(Ordering ordering, string SearchKey, long? catid, int pagesize = 20, int page = 1)
        {
            return Ok(_productRepository.GetGames(ordering, SearchKey, pagesize, page, catid));
        }
        [HttpPost]
        [ProducesResponseType(typeof(Game), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResultDto<Game>>> CreateProduct([FromBody] Game product, [FromForm] Microsoft.AspNetCore.Http.IFormFile Files)
        {
          var res=  await _productRepository.CreateGame(product,new List<Microsoft.AspNetCore.Http.IFormFile> { Files});

            return CreatedAtRoute("GetProduct", new { id = res.Data}, res);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ResultDto<Game>), (int)HttpStatusCode.OK)]
      
        public async Task<ActionResult<ResultDto<Game>>> UpdateProduct([FromBody] Game product, [FromForm] Microsoft.AspNetCore.Http.IFormFile Files)
        {
            return Ok(await _productRepository.UpdateGame(product, new List<Microsoft.AspNetCore.Http.IFormFile> { Files }));
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ResultDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResultDto>> DeleteProductById(long id)
        {
            return Ok(await _productRepository.DeleteGame(id));
        }
    }
}
