namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IPaymentMethodService
{
    IEnumerable<PaymentMethod> GetAll();
    PaymentMethod GetById(int id);
    void Create(PaymentMethodRequest paymentMethodRequest);
    void Update(int id, PaymentMethodRequest paymentMethodRequest);
    void Delete(int id);
}

public class PaymentMethodService : IPaymentMethodService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public PaymentMethodService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(PaymentMethodRequest paymentMethodRequest)
    {
        var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodRequest);
        _context.PaymentMethods.Add(paymentMethod);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var paymentMethod = getPaymentMethodId(id);
        _context.PaymentMethods.Remove(paymentMethod);
        _context.SaveChanges();
    }

    public IEnumerable<PaymentMethod> GetAll()
    {
        return _context.PaymentMethods;
    }

    public PaymentMethod GetById(int id)
    {
        return getPaymentMethodId(id);
    }

    public void Update(int id, PaymentMethodRequest paymentMethodRequest)
    {
        var paymentMethod = getPaymentMethodId(id);
        _mapper.Map(paymentMethodRequest, paymentMethod);
        _context.Update(paymentMethod);
        _context.SaveChanges();
    }


    // helper methods

    private PaymentMethod getPaymentMethodId(int id)
    {
        var paymentMethod = _context.PaymentMethods.Find(id);
        if (paymentMethod == null) throw new KeyNotFoundException("PaymentMethods not found");
        return paymentMethod;
    }
}

