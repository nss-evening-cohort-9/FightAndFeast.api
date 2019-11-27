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
    public class InsuranceRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<Insurance> GetAllInsurance()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allInsurance = db.Query<Insurance>("Select * from [Insurance]");
                return allInsurance.AsList();
            }
        }

        public Insurance GetInsurance(int insuranceId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [Insurance]
                            where Id = @InsuranceId";
                var parameters = new
                {
                    InsuranceId = insuranceId
                };
                var insurance = db.QueryFirst<Insurance>(sql, parameters);
                return insurance;
            }
        }

        public bool AddInsurance(AddInsuranceCommand newInsurance)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[Insurance]
                                       ([Provider]
                                       ,[TypeId])
                                 VALUES
                                       (@provider
                                       ,@typeId)";
                return db.Execute(sql, newInsurance) == 1;
            }
        }

        public bool UpdateInsurance(Insurance insuranceToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Insurance]
                               SET [Provider] = @provider
                                  ,[TypeId] = @typeId
                             WHERE Id = @id";
                insuranceToUpdate.Id = id;
                return db.Execute(sql, insuranceToUpdate) == 1;
            }
        }

        public bool DeleteInsurance(Insurance insuranceToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[Insurance]
                               SET [Provider] = NULL
                                  ,[TypeId] = NULL
                             WHERE Id = @id";
                insuranceToDelete.Id = id;
                return db.Execute(sql, insuranceToDelete) == 1;
            }
        }
    }
}
