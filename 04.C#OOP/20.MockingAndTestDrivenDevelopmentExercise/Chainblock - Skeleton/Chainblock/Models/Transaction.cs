namespace Chainblock
{
    using Contracts;
    using System;
    using Exceptions;
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus transactionStatus, string from, string to, decimal amount)
        {
            Id = id;
            Status = transactionStatus;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id 
        { 
            get { return id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_ID_EXCEPTION);
                }
                id = value;
            }
        }
        public TransactionStatus Status { get; set; }
        public string From 
        { 
            get { return from; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_SENDER_EXCEPTION);
                }
                from = value;
            }
        }
        public string To 
        { 
            get { return to; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_RECIVER_EXCEPTION);
                }
                to = value;
            }
        }
        public decimal Amount 
        { 
            get {  return amount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_AMOUNT_EXCEPTION);
                }
                amount = value;
            }
        }
    }
}