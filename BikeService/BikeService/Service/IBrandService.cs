namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IBrandService
{
    IEnumerable<Brand> GetAll();
    Brand GetById(int id);
    void Create(BrandRequest BrandRequest);
    void Update(int id, BrandRequest BrandRequest);
    void Delete(int id);
}

public class BrandService : IBrandService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public BrandService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(BrandRequest BrandRequest)
    {
        var brand = _mapper.Map<Brand>(BrandRequest);
        _context.Brands.Add(brand);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var brand = getBrandId(id);
        _context.Brands.Remove(brand);
        _context.SaveChanges();
    }

    public IEnumerable<Brand> GetAll()
    {
        return _context.Brands;
    }

    public Brand GetById(int id)
    {
        return getBrandId(id);
    }

    public void Update(int id, BrandRequest brandRequest)
    {
        var brand = getBrandId(id);
        _mapper.Map(brandRequest, brand);
        _context.Update(brand);
        _context.SaveChanges();
    }


    // helper methods

    private Brand getBrandId(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null) throw new KeyNotFoundException("Brand not found");
        return brand;
    }
}

