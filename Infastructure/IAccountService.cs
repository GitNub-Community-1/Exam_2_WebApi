namespace DefaultNamespace;

using Domain;

public interface IAccountService
{
    public Task<int> AddAccount(Account account);
    public Task<int> UpdateAccount(Account account);
    public Task<int> DeleteAccount(int id);
    public Task<Account> GetAccountById(int id);
    public Task<List<Account>> GetAllAccounts();
}