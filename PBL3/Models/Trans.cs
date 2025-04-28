namespace PBL3
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Trans
    {
        [Key]
        public ulong TransactionId { get; private set; }
        [Required]
        public string TransactionDate { get; private set; } = DateTime.Now.ToString("G");

        public string TransactionType { get; private set; }
        [ForeignKey("FromAccountId")]
        public int FromAccountId { get; private set; }
        [ForeignKey("ToAccountId")]
        public int ToAccountId { get; private set; }
        public double Amount { get; private set; }
        public virtual BankAccount FromAccount { get; private set; }
        public virtual BankAccount ToAccount { get; private set; }

        //public string GetData()
        //{
        //    return $"Transaction|{TransactionId}|{TransactionType}|{Username}|{FromAccountId}|{ToAccountId}|{Amount}|{TransactionDate}";
        //}

        //public void DisplayInfo()
        //{
        //    Console.WriteLine($"Transaction ID: {TransactionId} | Type: {TransactionType} | Username: {Username} | From Account: {FromAccountId} | To Account: {ToAccountId} | Amount: {Amount} | Date: {TransactionDate}");
        //}
        public Trans() { }
        public static ulong GenerateUniqueTransactionId()
        {
            // Explicitly cast DateTime.Now.Ticks to ulong to resolve ambiguity
            return (ulong)DateTime.Now.Ticks % ulong.MaxValue;
        }
    }

}
