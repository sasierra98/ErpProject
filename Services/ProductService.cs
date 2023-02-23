using ErpProject.Models;

namespace ErpProject.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(long id);
    Product Create(Product product);
    Product Update(Product product);
    void Delete(long id);
}

public class ProductService : IProductService
{
    private readonly DataContext _dataContext;

    public ProductService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public IEnumerable<Product> GetAll()
    {
        return _dataContext.Products;
    }

    public Product? GetById(long id)
    {
        return _dataContext.Products.Find(id);
    }

    public Product Create(Product product)
    {
        _dataContext.Products.Add(product);
        _dataContext.SaveChanges();
        return product;
    }

    public Product Update(Product product)
    {
        _dataContext.ChangeTracker.Clear();
        _dataContext.Products.Update(product);
        _dataContext.SaveChanges();
        return product;
    }

    public void Delete(long id)
    {
        var product = _dataContext.Find<Product>(id);
        _dataContext.Products.Remove(product);
        _dataContext.SaveChanges();
    }
}