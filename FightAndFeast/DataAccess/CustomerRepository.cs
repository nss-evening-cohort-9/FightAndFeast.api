using Dapper;
using FightAndFeast.Commands;
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
                var allCustomers = db.Query<Customer>("Select * from [Customer]");
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

        public bool AddCustomer(AddCustomerCommand newCustomer)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[Customer]
                                       ([FirstName]
                                       ,[LastName]
                                       ,[DateCreated]
                                       ,[HasFought]
                                       ,[Email]
                                       ,[Phone])
                                 VALUES
                                       (@firstName
                                       ,@lastName
                                       ,@dateCreated
                                       ,@hasFought
                                       ,@email
                                       ,@phone)";
                
                return db.Execute(sql, newCustomer) == 1;
            }
        }

        public bool UpdateCustomer(Customer customerToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Customer]
                               SET [FirstName] = @firstName
                                  ,[LastName] = @lastName
                                  ,[HasFought] = @hasFought
                                  ,[Email] = @email
                                  ,[Phone] = @phone
                             WHERE Id = @id";
                customerToUpdate.Id = id;
                return db.Execute(sql, customerToUpdate) == 1;
            }
        }

        public bool DeleteCustomer(Customer customerToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Customer]
                               SET [FirstName] = NULL
                                  ,[LastName] = NULL
                                  ,[Email] = NULL
                                  ,[Phone] = NULL
                             WHERE Id = @id";
                customerToDelete.Id = id;
                return db.Execute(sql, customerToDelete) == 1;
            }
        }
    }
}
