
using Domain;


using Dapper;
namespace DefaultNamespace;
public class AccountService(DbContext context)
{
    public async Task<int> AddAccount(Account account)
    {
        using var conn = context.Connection();
        string query = "insert into accounts(accountnumber,accounttype,customer_id,balance) values(@accountnumber,@accounttype,@customer_id,@balance)";
        var i = await conn.ExecuteAsync(query, new{account.AccountNumber,account.AccountType,account.customer_id,account.Balance});
        return i;
    }

    public async Task<int> DeleteAccount(int id)
    {
        using var conn = context.Connection();
        string query = "delete from accounts where id = @id";
        var i = await conn.ExecuteAsync(query, new{id});
        return i;
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        using var conn = context.Connection();
        string query = "select * from accounts";
        var result = (await conn.QueryAsync<Account>(query)).ToList();
        return result;
    }

    public async Task<Account> GetCustomerById(int id)
    {
        using var conn = context.Connection();
        string query = "select * from accounts where id = @id";
        var result = (await conn.QueryFirstOrDefaultAsync( query, new{id}));
        return result;
    }

    public async Task<int> UpdateAccount(Account account)
    {
        using var conn = context.Connection();
        string query = "update accounts set accountnumber = @accountnumber, accounttype = @accountype, @customer_id, balance = @balance where id = @id";
        var i = await conn.ExecuteAsync(query,new{account.AccountNumber,account.AccountType,account.customer_id,account.Balance,account.Id});
        return i;
    }
}