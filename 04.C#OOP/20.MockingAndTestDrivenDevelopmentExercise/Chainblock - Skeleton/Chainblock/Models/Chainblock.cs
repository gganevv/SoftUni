namespace Chainblock
{
    using Contracts;
    using global::Chainblock.Exceptions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Chainblock : IChainblock
    {
        private HashSet<ITransaction> transactions;
        public Chainblock()
        {
            transactions = new HashSet<ITransaction>();
        }
        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new ArgumentException(ExceptionMessages.TRANSACTION_ALREADY_EXISTS_MESSAGE);
            }
            transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction tx = transactions.FirstOrDefault(x => x.Id == id);
            if (tx == null)
            {
                throw new ArgumentException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            tx.Status = newStatus;
        }

        public bool Contains(ITransaction tx) => transactions.Any(x => x.Id == tx.Id);

        public bool Contains(int id) => transactions.Any(x => x.Id == id);

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.Amount >= lo && tx.Amount <= hi)
                {
                    transactions.Add(tx);
                }
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id))
            {
                transactions.Add(tx);
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> recivers = new List<string>();
            foreach (var tx in transactions.OrderByDescending(x => x.Amount))
            {
                if (tx.Status == status)
                {
                    recivers.Add(tx.To);
                }
            }
            if (!recivers.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }

            return recivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = new List<string>();
            foreach (var tx in transactions.OrderByDescending(x => x.Amount))
            {
                if (tx.Status == status)
                {
                    senders.Add(tx.From);
                }
            }
            if (!senders.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction tx = transactions.FirstOrDefault(x => x.Id == id);
            if (tx == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return tx;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.To == receiver && tx.Amount >= lo && tx.Amount <= hi)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }


        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.To == receiver)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }

            return transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.From == sender && tx.Amount >= amount)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.From == sender)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }

            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.Status == status)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount)
        {
            HashSet<ITransaction> transactions = new HashSet<ITransaction>();
            foreach (var tx in this.transactions)
            {
                if (tx.Status == status && tx.Amount <= amount)
                {
                    transactions.Add(tx);
                }
            }
            if (!transactions.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in transactions)
            {
                yield return item;
            }
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction tx = transactions.FirstOrDefault(x => x.Id == id);
            if (tx == null)
            {
                throw new ArgumentException(ExceptionMessages.NO_SUCH_TRANSACTION_EXISTS);
            }
            transactions.Remove(tx);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
