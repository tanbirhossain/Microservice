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
            //using (var _context = new CustomerDBContext())
            //{
            //    try
            //    {
            //        Console.WriteLine(" >>>>  Start  Database migration  <<<<<");
            //        _context.Database.EnsureCreated();
            //        // Look for any customer.
            //        if (_context.tbl_Customers.Any())
            //        {
            //            Console.WriteLine(" >>>>  Completed  Database migration : Already exits  <<<<<");
            //            return;   // DB has been seeded
            //        }

            //        // tbl_Customer

            //        var result = _context.tbl_Customers.Add(
            //               new tbl_Customer { Name = "Ovi" }
            //               );
            //        var _result = result.Entity;
            //        _context.SaveChanges();


            //        Console.WriteLine(" >>>>  Completed  Database migration  <<<<<");
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }


            //}

        }
    }

    public static class DbInitializer
    {
        public static void Initialize(CustomerDBContext context)
        {
            Console.WriteLine(" >>>>  Start  Database migration  <<<<<");

            try
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.tbl_Customers.Any())
                {

                    Console.WriteLine(" >>>>  Database already exists - Completed  Database migration  <<<<<");
                    return;   // DB has been seeded

                }

                var result = context.tbl_Customers.Add(
                              new tbl_Customer { Name = "Ovi" }
                              );
                var _result = result.Entity;
                context.SaveChanges();
                Console.WriteLine(" >>>>  Completed  Database migration  <<<<<");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >>>>  EXception  <<<<<" + ex);

                throw;
            }


            //Console.WriteLine(" >>>>  Completed  Database migration  <<<<<");
        }
    }
}
