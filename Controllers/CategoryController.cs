using ErpProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErpProject.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<Category> _logger;

    private static List<Category> ListCategory = new ();

    public CategoryController(ILogger<Category> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IEnumerable<Category> Get()
    {
        return ListCategory;
    }
}