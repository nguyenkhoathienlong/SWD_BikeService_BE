namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;
using Microsoft.EntityFrameworkCore;

public interface IStoreService
{
    IEnumerable<StoreInfo> GetAll();
    Store GetById(int id);
    IEnumerable<Store> GetByName(string name);
    void Create(StoreRequest storeRequest);
    void Update(int id, StoreRequest storeRequest);
    void Delete(int id);
}

public class StoreService : IStoreService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public StoreService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(StoreRequest storeRequest)
    {
        var store = _mapper.Map<Store>(storeRequest);
        _context.Stores.Add(store);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var store = getStoreId(id);
        _context.Stores.Remove(store);
        _context.SaveChanges();
    }

    public IEnumerable<StoreInfo> GetAll()
    {
        var store = _context.Stores.Where(x => true)
            .Include(x => x.Ward)
            .ThenInclude(x => x.Area)
            .ThenInclude(x => x.District)
            .Select(x => new StoreInfo
            {
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                AreaName = x.Ward.Name,
                WardName = x.Ward.Area.Name,
                DistrictName = x.Ward.Area.District.Name,
            }).ToList();
        return store;
    }

    public Store GetById(int id)
    {
        return getStoreId(id);
    }

    public IEnumerable<Store> GetByName(string name)
    {
        IQueryable<Store> query = _context.Stores;
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }
        return query.ToList();
    }

    public void Update(int id, StoreRequest storeRequest)
    {
        var store = getStoreId(id);
        _mapper.Map(storeRequest, store);
        _context.Stores.Update(store);
        _context.SaveChanges();
    }

    private Store getStoreId(int id)
    {
        var store = _context.Stores.Find(id);
        if (store == null) throw new KeyNotFoundException("Store not found");
        return store;
    }
}

