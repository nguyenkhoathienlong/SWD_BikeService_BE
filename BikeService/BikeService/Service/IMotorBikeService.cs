namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using Microsoft.EntityFrameworkCore;

public interface IMotorbikeService
{
    IEnumerable<MotorbikeCustomer> GetAll();
    Motorbike GetById(int id);
    void Create(MotorbikeRequest motorbikeRequest);
    void Update(int id, MotorbikeRequest motorbikeRequest);
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

    public void Create(MotorbikeRequest motorbikeRequest)
    {
        var motorbike = _mapper.Map<Motorbike>(motorbikeRequest);
        _context.Motorbikes.Add(motorbike);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var motorbike = getMotorbikeId(id);
        _context.Motorbikes.Remove(motorbike);
        _context.SaveChanges();
    }

    public IEnumerable<MotorbikeCustomer> GetAll()
    {

        var bike = _context.Motorbikes.Where(x => true).Include(x => x.Customer).Select(x => new MotorbikeCustomer
        {
            CustomerName = x.Customer.Name,
            PhoneNumber = x.Customer.PhoneNumber,
            Email = x.Customer.Email,
            LicensePlate = x.LicensePlate
        }).ToList();
        return bike;

    }

    public Motorbike GetById(int id)
    {
        return getMotorbikeId(id);
    }

    public void Update(int id, MotorbikeRequest motorbikeRequest)
    {
        var motorbikeId = getMotorbikeId(id);
        _mapper.Map(motorbikeRequest, motorbikeId);
        _context.Update(motorbikeId);
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

