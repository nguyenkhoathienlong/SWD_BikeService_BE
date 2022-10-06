namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IDistrictService
{
    IEnumerable<District> GetAll();
    District GetById(int id);
    void Create(DistrictRequest districtRequest);
    void Update(int id, DistrictRequest districtRequest);
    void Delete(int id);
}

public class DistrictService : IDistrictService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public DistrictService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(DistrictRequest districtRequest)
    {
        var district = _mapper.Map<District>(districtRequest);
        _context.Districts.Add(district);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var district = getDistrictId(id);
        _context.Districts.Remove(district);
        _context.SaveChanges();
    }

    public IEnumerable<District> GetAll()
    {
        return _context.Districts;
    }

    public District GetById(int id)
    {
        return getDistrictId(id);
    }

    public void Update(int id, DistrictRequest districtRequest)
    {
        var district = getDistrictId(id);
        _mapper.Map(districtRequest, district);
        _context.Update(district);
        _context.SaveChanges();
    }


    // helper methods

    private District getDistrictId(int id)
    {
        var district = _context.Districts.Find(id);
        if (district == null) throw new KeyNotFoundException("District not found");
        return district;
    }
}

