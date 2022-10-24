namespace BikeService.Service;
using AutoMapper;
using BikeService.Data;
using BikeService.Helpers;
using BikeService.Models;
using BikeService.Models.Request;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(int id);
    void Create(CustomerRequest customerRequest);
    void Update(int id, CustomerRequest customerRequest);
    void Delete(int id);
}

public class CustomerService : ICustomerService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public CustomerService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(CustomerRequest customerRequest)
    {
        if (_context.Customers.Any(x => x.Email == customerRequest.Email))
        {
            throw new ThrowingException("Email " + customerRequest.Email + " already exists!");
        }
        if (_context.Customers.Any(x => x.PhoneNumber == customerRequest.PhoneNumber))
        {
            throw new ThrowingException("Your phone number " + customerRequest.PhoneNumber + " already exists!");
        }
        var customer = _mapper.Map<Customer>(customerRequest);
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var customer = getCustomerId(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer GetById(int id)
    {
        return getCustomerId(id);
    }

    public void Update(int id, CustomerRequest customerRequest)
    {
        if (_context.Customers.Any(x => x.Email == customerRequest.Email))
        {
            throw new ThrowingException("Your email " + customerRequest.Email + " will not change!");
        }
        if (_context.Customers.Any(x => x.PhoneNumber == customerRequest.PhoneNumber))
        {
            throw new ThrowingException("Your phone number " + customerRequest.PhoneNumber + " will not change!");
        }
        var customer = getCustomerId(id);
        _mapper.Map(customerRequest, customer);
        _context.Update(customer);
        _context.SaveChanges();
    }


    // helper methods

    private Customer getCustomerId(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null) throw new KeyNotFoundException("Customer not found");
        return customer;
    }
}

