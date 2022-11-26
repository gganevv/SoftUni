namespace Chainblock
{
    using Contracts;
    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus transactionStatus, string from, string to, decimal amount)
        {
            Id = id;
            Status = transactionStatus;
            From = from;
            To = to;
            Amount = amount;
        }
        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}