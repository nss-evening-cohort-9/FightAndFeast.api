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
    public class PaymentTypeRepository
    {
        string _connectionString = "Server=localhost; Database=FightAndFeast; Trusted_Connection=True;";

        public IEnumerable<PaymentType> GetAllPaymentTypes()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                var allPaymentTypes = db.Query<PaymentType>("Select * from [PaymentType]");
                return allPaymentTypes.AsList();
            }
        }

        public PaymentType GetPaymentType(int paymentTypeId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from [PaymentType]
                            where Id = @PaymentTypeId";
                var parameters = new
                {
                    PaymentTypeId = paymentTypeId
                };
                var paymentType = db.QueryFirst<PaymentType>(sql, parameters);
                return paymentType;
            }
        }

        public bool AddPaymentType(AddPaymentTypeCommand newPaymentType)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [dbo].[PaymentType]
                                       ([Name])
                                 VALUES
                                       (@name)";

                return db.Execute(sql, newPaymentType) == 1;
            }
        }

        public bool UpdatePaymentType(PaymentType paymentTypeToUpdate, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[PaymentType]
                               SET [Name] = @name
                             WHERE Id = @id";
                paymentTypeToUpdate.Id = id;
                return db.Execute(sql, paymentTypeToUpdate) == 1;
            }
        }

        public bool DeletePaymentType(PaymentType paymentTypeToDelete, int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE [dbo].[PaymentType]
                               SET [Name] = NULL
                             WHERE Id = @id";
                paymentTypeToDelete.Id = id;
                return db.Execute(sql, paymentTypeToDelete) == 1;
            }
        }
    }
}
