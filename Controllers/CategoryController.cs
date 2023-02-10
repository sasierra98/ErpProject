using ErpProject.Models;
using ErpProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpProject.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<Category> _logger;
    private readonly ICategoryService _categoryService;
    private string Uri = "api/v1/categories";
    
    
    public CategoryController(ICategoryService categoryService, ILogger<Category> logger)
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public IEnumerable<Category> GetAll()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        var category = _categoryService.GetById(id);
        if (category == null) return BadRequest("Category not found");
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Post(Category category)
    {
        var categoryPost = _categoryService.Create(category);
        return Created(Uri, categoryPost);
    }
}