using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Models;
using FightAndFeast.Commands;
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

        public bool AddSeller(AddSellerCommand newSeller)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var addSeller = @"INSERT INTO [dbo].[Seller]
	                                ([Name]
	                                ,[DateCreated])
                                 output inserted.*
                                 VALUES
	                                (@name
                                    ,@date)";

                var parameters = new
                {
                    name = newSeller.Name,
                    date = DateTime.Now

                };

                var rowsAffected = connection.Execute(addSeller, parameters);
                return rowsAffected == 1;
            }
        }

        public bool DeleteSeller(Seller sellerToDelete, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Seller]
	                        SET [Name] = null
                          WHERE [Id] = @id";

                sellerToDelete.Id = id;

                return connection.Execute(sql, sellerToDelete) == 1;
            }

        }

        public bool UpdateSeller(Seller sellerToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Seller]
	                            SET [Name] = @name
	                        WHERE [Id] = @id";

                sellerToUpdate.Id = id;

                return connection.Execute(sql, sellerToUpdate) == 1;
            }
        }
    }
}
