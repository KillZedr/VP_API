namespace VapeShop_API.ContractsExep
{
    public class DbConnectionExeption : Exception
    {
        public DbConnectionExeption(string? message) : base(message) { }

        public DbConnectionExeption(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
