namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Models;
using BikeService.Models.Request;

public interface IPaymentService
{
    IEnumerable<Payment> GetAll();
    Payment GetById(int id);
    void Create(PaymentRequest paymentRequest);
    void Update(int id, PaymentRequest paymentRequest);
    void Delete(int id);
}

public class PaymentService : IPaymentService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public PaymentService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(PaymentRequest paymentRequest)
    {
        var payment = _mapper.Map<Payment>(paymentRequest);
        _context.Payments.Add(payment);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var payment = getPaymentId(id);
        _context.Payments.Remove(payment);
        _context.SaveChanges();
    }

    public IEnumerable<Payment> GetAll()
    {
        return _context.Payments;
    }

    public Payment GetById(int id)
    {
        return getPaymentId(id);
    }

    public void Update(int id, PaymentRequest paymentRequest)
    {
        var payment = getPaymentId(id);
        _mapper.Map(paymentRequest, payment);
        _context.Update(payment);
        _context.SaveChanges();
    }


    // helper methods

    private Payment getPaymentId(int id)
    {
        var payment = _context.Payments.Find(id);
        if (payment == null) throw new KeyNotFoundException("Payments not found");
        return payment;
    }
}

