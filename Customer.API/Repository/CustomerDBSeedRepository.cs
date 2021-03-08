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
                    if (!_context.Database.CanConnect())
                    {
                        Console.WriteLine("Database cannot connected..... . ");
                    }


                    if (_context.tbl_Customers.Any())
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
                    var result = _context.tbl_Customers.Add(
                           new tbl_Customer { Name = "Ovi" }
                           );
                   var _result = result.Entity;
                    _context.SaveChanges();
                }

            }
        }
    }
}
