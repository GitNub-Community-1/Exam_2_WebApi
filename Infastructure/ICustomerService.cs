namespace DefaultNamespace;

using Domain;
public interface ICustomerService
{
    public  Task<int> AddCustomer(Customer customer);
    public  Task<int> UpdateCustomer ( Customer customer);
    public  Task<int> DeleteCustomer(int id);
    public  Task<Customer> GetCustomerById(int id);
    public  Task<List<Customer>> GetAllCustomers();
}