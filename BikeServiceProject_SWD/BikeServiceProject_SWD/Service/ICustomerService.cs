namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Helpers;
using BikeServiceProject_SWD.Models;
using BikeServiceProject_SWD.Models.Request;

public interface ICustomerService
{
    IEnumerable<CustomerRequest> GetAll();
    Customer GetById(int id);
    IEnumerable<CustomerRequest> GetCustomerByPhoneNumber(string phoneNumber);
    IEnumerable<CustomerRequest> GetCustomerByEmail(string email);
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

    public IEnumerable<CustomerRequest> GetAll()
    {
        return _context.Customers.Where(x => true).Select(x => new CustomerRequest
        {
            Name = x.Name,
            Email = x.Email,   
            PhoneNumber = x.PhoneNumber,
        }).ToList();
    }

    public Customer GetById(int id)
    {
        return getCustomerId(id);
    }

    public IEnumerable<CustomerRequest> GetCustomerByPhoneNumber(string phoneNumber)
    {
        IQueryable<CustomerRequest> query = _context.Customers.Where(x => true).Select(x => new CustomerRequest
        {
            Name = x.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
        });
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            query = query.Where(x => x.PhoneNumber.Equals(phoneNumber));
        }
        return query.ToList();
    }

    public IEnumerable<CustomerRequest> GetCustomerByEmail(string email)
    {
        IQueryable<CustomerRequest> query = _context.Customers.Where(x => true).Select(x => new CustomerRequest
        {
            Name = x.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
        });
        if (!string.IsNullOrEmpty(email))
        {
            query = query.Where(x => x.Email.Equals(email));
        }
        return query.ToList();
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

