using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Models;
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

                var allInsuranceTypes = connection.Query<InsuranceType>(@"Select * From [InsuranceTypes]");

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


            }
        }
    }
}
