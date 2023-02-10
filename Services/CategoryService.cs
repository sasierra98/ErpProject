using System.Collections;
using ErpProject.Models;

namespace ErpProject.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category? GetById(long id);
    Category Create(Category category);
    void Update(int id, Category category);
    void Delete(int id);
}

public class CategoryService : ICategoryService
{
    private DataContext _dataContext;
    public CategoryService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public IEnumerable<Category> GetAll()
    {
        return _dataContext.Categories;
    }

    public Category? GetById(long id)
    {
        var category = _dataContext.Categories.Find(id);
        return category;
    }

    public Category Create(Category category)
    {
        _dataContext.Categories.Add(category);
        var categoryData= _dataContext.SaveChanges();
        return category;
    }

    public void Update(int id, Category category)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}