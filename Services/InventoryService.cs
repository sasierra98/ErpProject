using System.Collections;
using ErpProject.Models;

namespace ErpProject.Services;

public interface IInventoryService
{
    IEnumerable<Inventory> GetAll();
    Inventory? GetById(long id);
    Inventory Create(Inventory inventory);
    Inventory Update(Inventory inventory);
    void Delete(long id);
}

public class InventoryService : IInventoryService
{
    private DataContext _dataContext;
    public InventoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<Inventory> GetAll()
    {
        return _dataContext.Inventories;
    }

    public Inventory? GetById(long id)
    {
        return _dataContext.Inventories.Find(id);
    }

    public Inventory Create(Inventory inventory)
    {
        _dataContext.Inventories.Add(inventory);
        _dataContext.SaveChanges();
        return inventory;
    }

    public Inventory Update(Inventory inventory)
    {
        _dataContext.ChangeTracker.Clear();
        _dataContext.Inventories.Update(inventory);
        _dataContext.SaveChanges();
        return inventory;
    }

    public void Delete(long id)
    {
        var inventory = _dataContext.Inventories.Find(id);
        _dataContext.Inventories.Remove(inventory);
        _dataContext.SaveChanges();
    }
}