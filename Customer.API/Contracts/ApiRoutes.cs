namespace Customer.API.Contracts
{
    public static class ApiRoutes
    {
        //private const string 
        public static class Customer
        {
            public const string Add = "api/v1/Customer/Add";
            public const string Update = "api/v1/Customer/Update";
            public const string GetById = "api/v1/Customer/GetById/{id}";
            public const string GetAll = "api/v1/Customer/GetAll";
            public const string RemoveById = "api/v1/Customer/RemoveById/{id}";
        }
    }
}
