using Dapper;
using FightAndFeast.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FightAndFeast.DataAccess
{
    public class ProductTypeRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<ProductType> GetAllProductTypes()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allProductTypes = db.Query<ProductType>("Select * from [ProductType]");
                return allProductTypes.AsList();
            }
        }

        public ProductType GetProductType(int productTypeId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [ProductType]
                            where Id = @ProductTypeId";
                var parameters = new
                {
                    ProductTypeId = productTypeId
                };
                var productType = db.QueryFirst<ProductType>(sql, parameters);
                return productType;
            }
        }

        public bool AddProductType(AddProductTypeCommand newProductType)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[ProductType]
                                       ([Name])
                                 VALUES
                                       (@name)";

                return db.Execute(sql, newProductType) == 1;
            }
        }

        public bool UpdateProductType(ProductType productTypeToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[ProductType]
                               SET [Name] = @name
                             WHERE Id = @id";
                productTypeToUpdate.Id = id;
                return db.Execute(sql, productTypeToUpdate) == 1;
            }
        }

        public bool DeleteProductType(ProductType productTypeToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[ProductType]
                               SET [Name] = NULL
                             WHERE Id = @id";
                productTypeToDelete.Id = id;
                return db.Execute(sql, productTypeToDelete) == 1;
            }
        }
    }
}
