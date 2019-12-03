using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Models;
using FightAndFeast.Commands;
using System.Data.SqlClient;
using Dapper;

namespace FightAndFeast.DataAccess
{
    public class InsuranceTypeRepository
    {
        string _connectionString = "Server=localhost;Database=FightAndFeast;Trusted_Connection=True;";

        public IEnumerable<InsuranceType> GetAllInsuranceTypes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var allInsuranceTypes = connection.Query<InsuranceType>(@"Select * From [InsuranceType]");

                return allInsuranceTypes.AsList();
            }
        }

        public InsuranceType GetInsuranceType(int insuranceTypeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"select *
                            from [InsuranceType]
                            where Id = @InsuranceTypeId";

                var parameters = new
                {
                    InsuranceTypeId = insuranceTypeId
                };

                var insuranceType = connection.QueryFirst<InsuranceType>(sql, parameters);

                return insuranceType;
            }
        }

        public bool AddInsuranceType(AddInsuranceTypeCommand newInsuranceType)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"INSERT INTO [dbo].[InsuranceType]
	                            ([Name])
                            output inserted.*
                            VALUES
                                (@name)";

                var parameters = new
                {
                    name = newInsuranceType.Name
                };

                var rowsAffected = connection.Execute(sql, parameters);
                return rowsAffected == 1;
            }
        }

        public bool UpdateInsuranceType(InsuranceType typeToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[InsuranceType]
	                            SET [Name] = @name                                    
	                            WHERE [Id] = @id";

                typeToUpdate.Id = id;

                return connection.Execute(sql, typeToUpdate) == 1;
            }
        }

        public bool DeleteInsuranceType(InsuranceType insuranceTypeToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[InsuranceType]
                               SET [Name] = NULL
                             WHERE Id = @id";

                insuranceTypeToDelete.Id = id;

                return db.Execute(sql, insuranceTypeToDelete) == 1;
            }
        }
    }
}
