namespace Chainblock.Exceptions
{
    public static class ExceptionMessages
    {
        public const string TRANSACTION_ALREADY_EXISTS_MESSAGE =
            "Transaction already exists!";
        public const string NO_SUCH_TRANSACTION_EXISTS =
            "No such transaction exists!";
        public const string INVALID_ID_EXCEPTION =
            "Id cannot be zero or negative!";
        public const string INVALID_SENDER_EXCEPTION =
            "Sender cannot be null or empty!";
        public const string INVALID_RECIVER_EXCEPTION =
            "Reciver cannot be null or empty!";
        public const string INVALID_AMOUNT_EXCEPTION =
            "Amount cannot be zero or negative!";
    }
}
