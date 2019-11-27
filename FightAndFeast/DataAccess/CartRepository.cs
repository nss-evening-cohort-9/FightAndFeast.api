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
    public class CartRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<Cart> GetAllCarts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allCarts = db.Query<Cart>("Select * from [Cart]");
                return allCarts.AsList();
            }
        }

        public Cart GetCart(int cartId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [Cart]
                            where Id = @CartId";
                var parameters = new
                {
                    CartId = cartId
                };
                var cart = db.QueryFirst<Cart>(sql, parameters);
                return cart;
            }
        }

        public bool AddCart(AddCartCommand newCart)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[Cart]
                                       ([Total])
                                 VALUES
                                       (@total)";

                return db.Execute(sql, newCart) == 1;
            }
        }

        public bool UpdateCart(Cart cartToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Cart]
                               SET [Total] = @total
                             WHERE Id = @id";
                cartToUpdate.Id = id;
                return db.Execute(sql, cartToUpdate) == 1;
            }
        }

        public bool DeleteCart(Cart cartToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"Delete from [dbo].[Cart]
                             WHERE Id = @id";
                cartToDelete.Id = id;
                return db.Execute(sql, cartToDelete) == 1;
            }
        }
    }
}
