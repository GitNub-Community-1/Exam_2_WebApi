namespace DefaultNamespace;

public interface IAccountService
{
    public async Task<int> AddAccount(Account account);
    public async Task<int> UpdateAccount ( Account accout);
    public async Task<int> DeleteAccount(int id);
    public async Task<Account> GetAccountById(int id);
    public async Task<List<Account>> GetAllAccounts();
}