namespace Domain;

public class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public int customer_id { get; set; }
    public decimal Balance { get; set; }
}