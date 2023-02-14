using System.Collections;
using ErpProject.Models;

namespace ErpProject.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category? GetById(long id);
    Category Create(Category category);
    Category Update(Category category);
    void Delete(long id);
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

    public Category Update(Category category)
    {
        _dataContext.ChangeTracker.Clear();
        _dataContext.Categories.Update(category);
        _dataContext.SaveChanges();
        return category;
    }

    public void Delete(long id)
    {
        var category = _dataContext.Find<Category>(id);
        _dataContext.Categories.Remove(category);
        _dataContext.SaveChanges();
    }
}