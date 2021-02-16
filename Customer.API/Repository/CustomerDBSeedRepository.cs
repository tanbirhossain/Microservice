using Customer.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Repository
{
    public interface ISeedRepository
    {
        void DoSeed();
    }
    public class CustomerDBSeedRepository : ISeedRepository
    {
        public void DoSeed()
        {
            using (var _context = new CustomerDBContext())
            {

                try
                {
                    //  check database already created or not
                    if (_context.Database.CanConnect())
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database cannot connected..... . ");
                    Console.WriteLine("Ensure your database connection");
                    throw ex;
                }

                _context.Database.EnsureCreated();

                // tbl_Customer
                if (!_context.tbl_Customers.Any())
                {
                    _context.tbl_Customers.AddRange(
                        new tbl_Customer { Name = "Ovi" },
                        new tbl_Customer { Name = "Kashem" }
                        );

                    _context.SaveChanges();
                }

            }
        }
    }
}
