using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Models;
using Dapper;
using System.Data.SqlClient;

namespace FightAndFeast.DataAccess
{
    public class SellerRepository
    {
        string _connectionString = "Server=localhost;Database=FightAndFeast;Trusted_Connection=True;";

        public List<Seller> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sellers = connection.Query<Seller>("Select * from Seller");

                return sellers.AsList();
            }

        }

        public Seller Get(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"select * from Seller where Seller.Name = @sellerName";

                var parameters = new
                {
                    sellerName = name
                };

                var seller = connection.QueryFirst<Seller>(sql, parameters);

                return seller;

            }
        }
    }
}
