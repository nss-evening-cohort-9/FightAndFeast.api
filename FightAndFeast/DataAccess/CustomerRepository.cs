using Dapper;
using FightAndFeast.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.DataAccess
{
    public class CustomerRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allCustomers = db.Query<Customer>("Select * from Customer");
                return allCustomers.AsList();
            }
        }

        public Customer GetCustomer(int customerId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [Customer]
                            where Id = @CustomerId";
                var parameters = new
                {
                    CustomerId = customerId
                };
                var customer = db.QueryFirst<Customer>(sql, parameters);
                return customer;
            }
        }
    }
}
