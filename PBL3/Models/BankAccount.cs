using PBL3;
using PBL3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BankAccount
{
    private int accountId;
    private string createdDate;
    private double balance;
    private bool isFrozen;
    private bool isFlagged;
    private string sdt;

    [Key]
    public int AccountId { get => accountId; set => accountId = value; }
    [Required]
    public string CreatedDate { get => createdDate; set => createdDate = DateTime.Now.ToString("G"); }
    [Required]
    public double Balance { get => balance; set => balance = value; }
    public bool IsFrozen1 { get => isFrozen; set => isFrozen = value; }
    public bool IsFlagged { get => isFlagged; set => isFlagged = value; }
    public virtual ICollection<Trans> SentTransactions { get; set; }
    public virtual ICollection<Trans> ReceivedTransactions { get; set; }

    [ForeignKey("Sdt")]
    protected string Sdt { get; set; }
    protected virtual User User { get; set; }

    public BankAccount()
    {
        SentTransactions = new HashSet<Trans>();
        ReceivedTransactions = new HashSet<Trans>();
    }
    public void Freeze() => isFrozen = true;
    public void UnFreeze() => isFrozen = false;
    public void SetAccountId(int id) => accountId = id;

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void ReceiveTransfer(double amount)
    {
        balance += amount;
    }

    public static int GenerateAccountId(List<int> usedAccountIds)
    {
        var rand = new Random();
        int id;
        do
        {
            id = rand.Next(10000000, 99999999); // 8 chữ số
        } while (usedAccountIds.Contains(id));
        return id;
    }

    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    public abstract void DisplayInfo();           // có thể trả về chuỗi thay vì in
    public abstract string GetData();
    public abstract string GetAccountType();
    public abstract bool Withdraw(double amount);
    public abstract bool Transfer(double amount, BankAccount bankAcc);
    public abstract void MonthlyUpdate();
}
