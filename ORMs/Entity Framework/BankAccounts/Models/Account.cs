#pragma warning disable CS8618
namespace BankAccounts.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    [Key]
    public int TransactionId {get; set;}

    [Display(Name = "Deposit/Withdraw")]
    public int Amount {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public int UserId {get; set;}
}