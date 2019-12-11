using Dapper;
using FightAndFeast.Commands;
using FightAndFeast.Dtos;
using FightAndFeast.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.DataAccess
{
    public class ClubProductRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<ClubProductDto> GetAllClubProducts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allClubProducts = db.Query<ClubProductDto>(@"SELECT 
	                                                            cp.Id as ClubProductId, 
	                                                            c.Name AS ClubName, 
	                                                            c.Address, 
	                                                            c.Phone,
	                                                            p.Name AS ProductName,
	                                                            p.Price,
	                                                            p.Description AS ProductDescription,
                                                                p.DateCreated,
                                                                p.EventDate
                                                            FROM 
	                                                            [ClubProduct] cp
	                                                            JOIN [Club] c ON c.Id = cp.ClubId
	                                                            JOIN [Product] p ON p.Id = cp.ClubId
                                                            ORDER BY 
	                                                            cp.Id");
                return allClubProducts.AsList();
            }
        }

        public ClubProductDto GetClubProduct(int clubProductId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT 
	                            cp.Id as ClubProductId, 
	                            c.Name AS ClubName, 
	                            c.Address, 
	                            c.Phone,
	                            p.Name AS productName,
	                            p.Price,
	                            p.Description AS productDescription,
                                p.DateCreated,
                                p.EventDate
                            FROM 
	                            [ClubProduct] cp
	                            JOIN [Club] c ON c.Id = cp.ClubId
	                            JOIN [Product] p ON p.Id = cp.ClubId
                            WHERE cp.Id = @ClubProductId";
                var parameters = new
                {
                    ClubProductId = clubProductId
                };
                var clubProduct = db.QueryFirst<ClubProductDto>(sql, parameters);
                return clubProduct;
            }
        }

        public IEnumerable<ClubProductDto> GetRecentClubProducts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allClubProducts = db.Query<ClubProductDto>(@"SELECT TOP 20
	                                                            cp.Id as ClubProductId, 
	                                                            c.Name AS ClubName, 
	                                                            c.Address, 
	                                                            c.Phone,
	                                                            p.Name AS ProductName,
	                                                            p.Price,
	                                                            p.Description AS ProductDescription,
                                                                p.DateCreated,
                                                                p.EventDate
                                                            FROM 
	                                                            [ClubProduct] cp
	                                                            JOIN [Club] c ON c.Id = cp.ClubId
	                                                            JOIN [Product] p ON p.Id = cp.ClubId
                                                            ORDER BY 
	                                                            p.EventDate");
                return allClubProducts.AsList();
            }
        }

        public bool AddClubProduct(AddClubProductCommand newClubProduct)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[ClubProduct]
                                       ([ClubId]
                                       ,[ProductId])
                                 VALUES
                                       (@clubId
                                       ,@productId)";

                return db.Execute(sql, newClubProduct) == 1;
            }
        }

        public bool UpdateClubProduct(ClubProduct clubProductToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[ClubProduct]
                               SET [ClubId] = @clubId
                                   ,[ProductId = @productId
                             WHERE Id = @id";
                clubProductToUpdate.Id = id;
                return db.Execute(sql, clubProductToUpdate) == 1;
            }
        }

        public bool DeleteClubProduct(ClubProduct clubProductToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"Delete from [dbo].[ClubProduct]
                             WHERE Id = @id";
                clubProductToDelete.Id = id;
                return db.Execute(sql, clubProductToDelete) == 1;
            }
        }
    }
}
