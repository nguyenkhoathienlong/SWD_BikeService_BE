namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

public interface IWardService
{
    IEnumerable<Ward> GetAll();
    Ward GetById(int id);
    void Create(WardRequest wardRequest);
    void Update(int id, WardRequest wardRequest);
    void Delete(int id);
}

public class WardService : IWardService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public WardService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(WardRequest wardRequest)
    {
        var ward = _mapper.Map<Ward>(wardRequest);
        _context.Wards.Add(ward);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var ward = getWardId(id);
        _context.Wards.Remove(ward);
        _context.SaveChanges();
    }

    public IEnumerable<Ward> GetAll()
    {
        return _context.Wards;
    }

    public Ward GetById(int id)
    {
        return getWardId(id);
    }

    public void Update(int id, WardRequest wardRequest)
    {
        var ward = getWardId(id);
        _mapper.Map(wardRequest, ward);
        _context.Wards.Update(ward);
        _context.SaveChanges();
    }

    private Ward getWardId(int id)
    {
        var ward = _context.Wards.Find(id);
        if (ward == null) throw new KeyNotFoundException("Ward not found");
        return ward;
    }
}

