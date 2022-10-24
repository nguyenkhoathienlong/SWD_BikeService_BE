namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IOrderService
{
    IEnumerable<Order> GetAll();
    Order GetById(int id);
    void Create(OrderRequest orderRequest);
    void Update(int id, OrderRequest orderRequest);
    void Delete(int id);
}

public class OrderService : IOrderService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(OrderRequest orderRequest)
    {
        var order = _mapper.Map<Order>(orderRequest);
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var order = getOrderId(id);
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders;
    }

    public Order GetById(int id)
    {
        return getOrderId(id);
    }

    public void Update(int id, OrderRequest orderRequest)
    {
        var order = getOrderId(id);
        _mapper.Map(orderRequest, order);
        _context.Update(order);
        _context.SaveChanges();
    }


    // helper methods

    private Order getOrderId(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) throw new KeyNotFoundException("Orders not found");
        return order;
    }
}

