using ErpProject.Models;
using ErpProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErpProject.Controllers;

[ApiController]
[Route("api/v1/inventories")]
public class InventoryController : ControllerBase
{
    private IInventoryService _inventoryService;
    private ILogger<Inventory> _logger;
    private const string Uri = "api/v1/inventories";

    public InventoryController(IInventoryService inventoryService, ILogger<Inventory> iLogger)
    {
        _inventoryService = inventoryService;
        _logger = iLogger;
    }
    
    [HttpGet]
    public ActionResult GetAll()
    {
        var inventory = _inventoryService.GetAll();
        return Ok(inventory);
    }

    [HttpGet("{id:long}")]
    public ActionResult GetById(long id)
    {
        var inventory = _inventoryService.GetById(id);
        if (inventory == null) return BadRequest("Inventory not found");
        return Ok(inventory);
    }

    [HttpPost]
    public ActionResult Post(Inventory inventory)
    {
        _inventoryService.Create(inventory);
        return Created(Uri, inventory);
    }

    [HttpPut("{id:long}")]
    public ActionResult Put(long id, Inventory inventory)
    {
        var inventoryPut = _inventoryService.GetById(id);
        if (inventoryPut == null) return BadRequest("Inventory not found");
        _inventoryService.Update(inventory);
        return Ok("Inventory Updated");
    }

    [HttpDelete("{id:long}")]
    public ActionResult Delete(long id)
    {
        var inventory = _inventoryService.GetById(id);
        if (inventory == null) return BadRequest("Inventory not found");
        return NoContent();
    }

}