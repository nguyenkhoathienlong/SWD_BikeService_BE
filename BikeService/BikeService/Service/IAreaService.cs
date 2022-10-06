namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IAreaService
{
    IEnumerable<Area> GetAll();
    Area GetById(int id);
    void Create(AreaRequest areaRequest);
    void Update(int id, AreaRequest areaRequest);
    void Delete(int id);
}

public class AreaService : IAreaService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public AreaService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(AreaRequest areaRequest)
    {
        var area = _mapper.Map<Area>(areaRequest);
        _context.Areas.Add(area);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var area = getAreaId(id);
        _context.Areas.Remove(area);
        _context.SaveChanges();
    }

    public IEnumerable<Area> GetAll()
    {
        return _context.Areas;
    }

    public Area GetById(int id)
    {
        return getAreaId(id);
    }

    public void Update(int id, AreaRequest areaRequest)
    {
        var area = getAreaId(id);   
        _mapper.Map(areaRequest, area);
        _context.Update(area);
        _context.SaveChanges();
    }


    // helper methods

    private Area getAreaId(int id)
    {
        var area = _context.Areas.Find(id);
        if (area == null) throw new KeyNotFoundException("Area not found");
        return area;
    }
}

