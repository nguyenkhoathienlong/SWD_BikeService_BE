namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    IEnumerable<Category> GetByName(string name);
    void Create(CategoryRequest categoryRequest);
    void Update(int id, CategoryRequest categoryRequest);
    void Delete(int id);
}

public class CategoryService : ICategoryService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(CategoryRequest categoryRequest)
    {
        var category = _mapper.Map<Category>(categoryRequest);
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var category = getCategoryId(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories;
    }

    public Category GetById(int id)
    {
        return getCategoryId(id);
    }

    public IEnumerable<Category> GetByName(string name)
    {
        IQueryable<Category> query = _context.Categories;
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }
        return query.ToList();
    }

    public void Update(int id, CategoryRequest categoryRequest)
    {
        var category = getCategoryId(id);
        _mapper.Map(categoryRequest, category);
        _context.Update(category);
        _context.SaveChanges();
    }


    // helper methods

    private Category getCategoryId(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        return category;
    }
}

