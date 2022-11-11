namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

public interface IManufacturerService
{
    IEnumerable<Manufacturer> GetAll();
    Manufacturer GetById(int id);
    IEnumerable<Manufacturer> GetByName(string name);
    void Create(ManufacturerRequest manufacturerRequest);
    void Update(int id, ManufacturerRequest manufacturerRequest);
    void Delete(int id);
}

public class ManufacturerService : IManufacturerService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public ManufacturerService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(ManufacturerRequest manufacturerRequest)
    {
        var manufacturer = _mapper.Map<Manufacturer>(manufacturerRequest);
        _context.Manufacturers.Add(manufacturer);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var manufacturer = getManufacturerId(id);
        _context.Manufacturers.Remove(manufacturer);
        _context.SaveChanges();
    }

    public IEnumerable<Manufacturer> GetAll()
    {
        return _context.Manufacturers;
    }

    public Manufacturer GetById(int id)
    {
        return getManufacturerId(id);
    }

    public IEnumerable<Manufacturer> GetByName(string name)
    {
        IQueryable<Manufacturer> query = _context.Manufacturers;
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }
        return query.ToList();
    }

    public void Update(int id, ManufacturerRequest manufacturerRequest)
    {
        var manufacturer = getManufacturerId(id);
        _mapper.Map(manufacturerRequest, manufacturer);
        _context.Update(manufacturer);
        _context.SaveChanges();
    }


    // helper methods

    private Manufacturer getManufacturerId(int id)
    {
        var manufacturer = _context.Manufacturers.Find(id);
        if (manufacturer == null) throw new KeyNotFoundException("Manufacturer not found");
        return manufacturer;
    }
}

