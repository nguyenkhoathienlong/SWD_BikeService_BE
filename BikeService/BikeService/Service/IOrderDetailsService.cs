namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IOrderDetailService
{
    IEnumerable<OrderDetail> GetAll();
    OrderDetail GetById(int id);
    void Create(OrderDetailsRequest OrderDetailRequest);
    void Update(int id, OrderDetailsRequest OrderDetailRequest);
    void Delete(int id);
}

public class OrderDetailService : IOrderDetailService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public OrderDetailService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(OrderDetailsRequest orderDetailRequest)
    {
        var orderDetail = _mapper.Map<OrderDetail>(orderDetailRequest);
        _context.OrderDetails.Add(orderDetail);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var orderDetail = getOrderDetailId(id);
        _context.OrderDetails.Remove(orderDetail);
        _context.SaveChanges();
    }

    public IEnumerable<OrderDetail> GetAll()
    {
        return _context.OrderDetails;
    }

    public OrderDetail GetById(int id)
    {
        return getOrderDetailId(id);
    }

    public void Update(int id, OrderDetailsRequest orderDetailRequest)
    {
        var orderDetail = getOrderDetailId(id);
        _mapper.Map(orderDetailRequest, orderDetail);
        _context.Update(orderDetail);
        _context.SaveChanges();
    }


    // helper methods

    private OrderDetail getOrderDetailId(int id)
    {
        var orderDetail = _context.OrderDetails.Find(id);
        if (orderDetail == null) throw new KeyNotFoundException("OrderDetails not found");
        return orderDetail;
    }
}

