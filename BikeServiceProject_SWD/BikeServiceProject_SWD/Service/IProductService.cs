namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;



public interface IProductService
{
    IEnumerable<Product> GetAll();
    IEnumerable<Product> GetAllService();
    Product GetById(int id);
    IEnumerable<Product> GetByName(string name);
    void Create(ProductRequest productRequest);
    void Update(int id, ProductRequest productRequest);
    void Delete(int id);
}

public class ProductService : IProductService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(ProductRequest productRequest)
    {
        var product = _mapper.Map<Product>(productRequest);
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = getProductId(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        IQueryable<Product> query = _context.Products;
        query = query.Where(x => x.IsActive == 1);
        return query.ToList();
    }

    public IEnumerable<Product> GetAllService()
    {
        IQueryable<Product> query = _context.Products;
        query = query.Where(x => x.IsService == 1 && x.IsActive == 1);
        return query.ToList();
    }

    public Product GetById(int id)
    {
        return getProductId(id);
    }

    public IEnumerable<Product> GetByName(string name)
    {
        IQueryable<Product> query = _context.Products;
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }
        return query.ToList();
    }

    public void Update(int id, ProductRequest productRequest)
    {
        var product = getProductId(id);
        _mapper.Map(productRequest, product);
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    private Product getProductId(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) throw new KeyNotFoundException("Product not found");
        return product;
    }
}

