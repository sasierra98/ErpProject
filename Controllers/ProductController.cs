using ErpProject.Models;
using ErpProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpProject.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<Product> _logger;
    private readonly IProductService _productService;
    private string Uri = "api/v1/products";

    public ProductController(IProductService productService, ILogger<Product> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id:long}")]
    public ActionResult GetById(long id)
    {
        var product = _productService.GetById(id);
        if (product == null) return BadRequest("Product not found");
        return Ok(product);
    }
    
    [HttpPost]
    public ActionResult Post(Product product)
    {
        var productPost = _productService.Create(product);
        return Created(Uri, productPost);
    }
    
    [HttpPut("{id:long}")]
    public ActionResult Put(long id, Product product)
    {
        var productPut = _productService.GetById(id);
        if (productPut == null) return BadRequest("Product not found");
        _productService.Update(product);
        return Ok("Product Updated");
    }
    
    [HttpDelete]
    public ActionResult Delete(long id)
    {
        var productPut = _productService.GetById(id);
        if (productPut == null) return BadRequest("Product not found");
        _productService.Delete(id);
        return NoContent();
    }


}