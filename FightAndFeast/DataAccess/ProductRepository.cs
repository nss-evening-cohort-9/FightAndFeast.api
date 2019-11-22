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
        public IEnumerable<Product> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from Product";
                var products = db.Query<Product>(sql);

                return products;
            }
        }
    
    public Product Get( int productId)
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


          }
    }

