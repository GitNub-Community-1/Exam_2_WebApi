using Microsoft.AspNetCore.Mvc;
using Domain;

namespace DefaultNamespace;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
	private readonly IAccountService _service;
	public AccountController(IAccountService service) => _service = service;

	[HttpGet]
	public async Task<List<Account>> GetAll()
	{
		var list = await _service.GetAllAccounts();
		return list;
	}

	[HttpGet("{id}")]
	public async Task<Account> GetById(int id)
	{
		var account = await _service.GetAccountById(id);
		return account;
	}

	[HttpPost]
	public async Task<string> CreateAccount(Account account)
	{
		int created = await _service.AddAccount(account);
		if (created > 0)
			return  "Account Added Succefully!";
        return "Account Added not succefully!";
	}

	[HttpPut("{id}")]
	public async Task<string> Update(int id, Account account)
	{
		var updated = await _service.UpdateAccount(account);
		if (updated > 0)  return "Account Updated Succefully!";
        return "Account Updated not succefully!";
	}

	[HttpDelete("{id}")]
	public async Task<string> Delete(int id)
	{
		var deleted = await _service.DeleteAccount(id);
		if (deleted > 0) return "Account Deleted Succefully!";
        return "Account Deleted not succefully!";
	}
}