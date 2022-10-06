namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;

public interface IMotorbikeService
{
    IEnumerable<Motorbike> GetAll();
    Motorbike GetById(int id);
    void Create(Motorbike Motorbike);
    void Update(int id, Motorbike Motorbike);
    void Delete(int id);
}

public class MotorbikeService : IMotorbikeService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public MotorbikeService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(Motorbike motorbike)
    {
        _context.Motorbikes.Add(motorbike);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var motorbike = getMotorbikeId(id);
        _context.Motorbikes.Remove(motorbike);
        _context.SaveChanges();
    }

    public IEnumerable<Motorbike> GetAll()
    {
        return _context.Motorbikes;
    }

    public Motorbike GetById(int id)
    {
        return getMotorbikeId(id);
    }

    public void Update(int id, Motorbike motorbike)
    {
        var motorbikeId = getMotorbikeId;
        _mapper.Map(motorbike, motorbikeId);
        _context.Update(motorbike);
        _context.SaveChanges();
    }


    // helper methods

    private Motorbike getMotorbikeId(int id)
    {
        var motorbike = _context.Motorbikes.Find(id);
        if (motorbike == null) throw new KeyNotFoundException("MotorBike not found");
        return motorbike;
    }
}

