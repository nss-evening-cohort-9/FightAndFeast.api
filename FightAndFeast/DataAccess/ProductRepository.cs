using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using FightAndFeast.Models;
using FightAndFeast.Commands;

namespace FightAndFeast.DataAccess
{
    public class ProductRepository
    {
        string _connectionString = "Server=localhost;Database=FightandFeast;Trusted_Connection=True;";
        public IEnumerable<Product> GetAllProducts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from Product";
                var products = db.Query<Product>(sql);

                return products;
            }
        }

        public Product GetProduct(int productId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                           from Product
                            where Id =@ProductId";
                var parameters = new
                {
                    ProductId = productId
                };
                var product = db.QueryFirst<Product>(sql, parameters);
                return product;
            }
        }

        public bool AddProduct(AddProductCommand newProduct)
        {

            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"Insert INTO [Product]
                                           ([Name]
                                            ,[Price]
                                            ,[Description])
                                          output inserted.*
                                          VALUES
                                                  (@name
                                                   ,@price
                                                   ,@description)";

                return db.Execute(sql, newProduct) == 1;
            }
        }

        public bool DeleteProduct(Product productToDelete, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE[dbo].[Product]
                                   SET [Name]= null
                                        ,[TypeId] = null  
                                       ,[Price] = null 
                                       ,[Description] = null
                                       WHERE [Id] = @id";
                productToDelete.Id = id;

                return connection.Execute(sql, productToDelete) == 1;
            }
        }

        public bool UpdateProduct(Product ProductToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"update [dbo].[Product]
                                    SET [Name] = @name,
                                        [TypeId] = @typeid,
                                        [Price] = @Price,
                                        [Description] = @description
                               WHERE [id] = @id";

                ProductToUpdate.Id = id;

                return connection.Execute(sql, ProductToUpdate) == 1;

            }
        }
    }

}


