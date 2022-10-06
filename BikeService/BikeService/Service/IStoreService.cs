namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;



public interface IStoreService
{
    IEnumerable<Store> GetAll();
    Store GetById(int id);
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

    public IEnumerable<Store> GetAll()
    {
        return _context.Stores;
    }

    public Store GetById(int id)
    {
        return getStoreId(id);
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

