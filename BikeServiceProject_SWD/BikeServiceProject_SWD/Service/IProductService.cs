namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Helpers;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;



public interface IProductService
{
    IEnumerable<ProductRequest> GetAll();
    IEnumerable<ProductRequest> GetAllActive();
    IEnumerable<ProductRequest> GetAllService();
    IEnumerable<ProductRequest> GetAllServiceActive();
    Product GetById(int id);
    IEnumerable<ProductRequest> GetByProductName(string name);
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

    public IEnumerable<ProductRequest> GetAllActive()
    {
        var productRequest = _context.Products.Where(x => x.IsActive == 1)
            .Select(x => new ProductRequest
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                ManufacturerId = x.ManufacturerId,
                CategoryId = x.CategoryId,
                StoreId = x.StoreId,
                IsService = x.IsService,
                IsActive = x.IsActive,
            }).ToList();
        return productRequest;
    }

    public IEnumerable<ProductRequest> GetAll()
    {
        var productRequest = _context.Products.Where(x => true)
            .Select(x => new ProductRequest
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                ManufacturerId = x.ManufacturerId,
                CategoryId = x.CategoryId,
                StoreId = x.StoreId,
                IsService = x.IsService,
                IsActive = x.IsActive,
            }).ToList();
        return productRequest;
    }

    public IEnumerable<ProductRequest> GetAllService()
    {
        var query = _context.Products.Where(x => x.IsService == 1)
            .Select(x => new ProductRequest
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                ManufacturerId = x.ManufacturerId,
                CategoryId = x.CategoryId,
                StoreId = x.StoreId,
                IsService = x.IsService,
                IsActive = x.IsActive,
            }).ToList();
        return query;
    }

    public IEnumerable<ProductRequest> GetAllServiceActive()
    {
        var query = _context.Products.Where(x => x.IsService == 1 && x.IsActive == 1)
            .Select(x => new ProductRequest
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                ManufacturerId = x.ManufacturerId,
                CategoryId = x.CategoryId,
                StoreId = x.StoreId,
                IsService = x.IsService,
                IsActive = x.IsActive,
            }).ToList();
        return query;
    }

    public Product GetById(int id)
    {
        return getProductId(id);
    }

    public IEnumerable<ProductRequest> GetByProductName(string name)
    {
        var query = _context.Products.Where(x => x.Name.Contains(name))
                .Select(x => new ProductRequest
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    ManufacturerId = x.ManufacturerId,
                    CategoryId = x.CategoryId,
                    StoreId = x.StoreId,
                    IsService = x.IsService,
                    IsActive = x.IsActive,
                }).ToList();
        return query;
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

