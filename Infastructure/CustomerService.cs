using Domain;
using Dapper;

namespace DefaultNamespace;

public class CustomerService(DbContext context) : ICustomerService
{
    public async Task<int> AddCustomer(Customer customer)
    {
        using var conn = context.Connection();
        string query =
            "insert into customers(name,email,phonenumber,address,profile_picture_url) values(@name,@email,@phonenumber,@address,@profile_picture_url)";
        int i = await conn.ExecuteAsync(query,
            new
            {
                customer.Name, customer.Email, customer.PhoneNumber, customer.Address, customer.Profile_picture_url
            });
        return i;
    }

    public async Task<int> DeleteCustomer(int id)
    {
        using var conn = context.Connection();
        string query = "delete from customers where id = @id";
        var i = await conn.ExecuteAsync(query, new { id });
        return i;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        using var conn = context.Connection();
        string query = "select * from customers";
        var result = (await conn.QueryAsync<Customer>(query)).ToList();
        return result;
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        using var conn = context.Connection();
        string query = "select * from customers where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync<Customer>(query, new { id }));
        return result;
    }

    public async Task<int> UpdateCustomer(Customer customer)
    {
        using var conn = context.Connection();
        string query =
            "update customers set name=@name,email=@email,phonenumber=@phonenumber,address=address,profile_picture_url = @profile_picture_url where id = @id";
        var i = await conn.ExecuteAsync(query,
            new
            {
                customer.Name, customer.Email, customer.PhoneNumber, customer.Address, customer.Profile_picture_url,
                customer.Id
            });
        return i;
    }
}