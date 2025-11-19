using Microsoft.AspNetCore.Mvc;
using Domain;
using Dtos;

namespace DefaultNamespace;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet]
    public async Task<List<Customer>> GetAll()
    {
        var list = await _service.GetAllCustomers();
        if (list is null) return null;
        return list;
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetById(int id)
    {
        var customer = await _service.GetCustomerById(id);
        if (customer is null) return null;
        return customer;
    }

    [HttpPost]
    public async Task<string> CreateCustomer(UploadPictureDto customer)
    {
        string uploadspath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        var filePath = Path.Combine(uploadspath, customer.ProfilePicture.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await customer.ProfilePicture.CopyToAsync(stream);
        }

        var userfile = new Customer
        {
            Name = customer.Name,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            Profile_picture_url = Path.Combine("Uploads",customer.ProfilePicture.FileName)
        };

        var created = await _service.AddCustomer(userfile);
        if (created > 0)
            return "Customer Added Succefully!";
        return "Customer Added not succefully!";
    }

    [HttpPut("{id}")]
    public async Task<string> Update(Customer customer)
    {
        var updated = await _service.UpdateCustomer(customer);
        if (updated > 0) return "Customer Updated Succefully!";
        return "Customer Updated not succefully!";
    }

    [HttpDelete("{id}")]
    public async Task<string> Delete(int id)
    {
        var deleted = await _service.DeleteCustomer(id);
        if (deleted > 0) return "Customer Deleted Succefully!";
        return "Customer Deleted not succefully!";
    }
}