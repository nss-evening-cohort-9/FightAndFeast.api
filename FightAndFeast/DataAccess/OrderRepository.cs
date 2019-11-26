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
    public class OrderRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<Order> GetAllOrders()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allOrders = db.Query<Order>("Select * from [Order]");
                return allOrders.AsList();
            }
        }

        public Order GetOrder(int orderId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [Order]
                            where Id = @OrderId";
                var parameters = new
                {
                    OrderId = orderId
                };
                var order = db.QueryFirst<Order>(sql, parameters);
                return order;
            }
        }

        public bool AddOrder(AddOrderCommand newOrder)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[Order]
                                       ([CustomerId]
                                       ,[Total]
                                       ,[CustomerPaymentTypeId])
                                 VALUES
                                       (@customerId
                                       ,@total
                                       ,@customerPaymentTypeId)";

                return db.Execute(sql, newOrder) == 1;
            }
        }

        public bool UpdateOrder(Order orderToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Order]
                               SET [Total] = @total
                                  ,[CustomerPaymentTypeId] = @customerPaymentTypeId
                             WHERE Id = @id";
                orderToUpdate.Id = id;
                return db.Execute(sql, orderToUpdate) == 1;
            }
        }

        public bool DeleteOrder(Order orderToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Order]
                               SET [CustomerPaymentTypeId] = NULL
                             WHERE Id = @id";
                orderToDelete.Id = id;
                return db.Execute(sql, orderToDelete) == 1;
            }
        }
    }
}
