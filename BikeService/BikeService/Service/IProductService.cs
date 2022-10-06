namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;



public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
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
        return _context.Products;
    }

    public Product GetById(int id)
    {
        return getProductId(id);
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

