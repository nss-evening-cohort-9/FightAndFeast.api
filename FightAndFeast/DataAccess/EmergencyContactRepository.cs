using FightAndFeast.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FightAndFeast.Commands;

namespace FightAndFeast.DataAccess
{
    public class EmergencyContactRepository
    {
        string _connectionString = "Server=localhost;Database=FightandFeast;Trusted_Connection=True;";
        public IEnumerable<EmergencyContact> GetAllEmergencyContacts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from EmergencyContact";
                var emergencycontact = db.Query<EmergencyContact>(sql);
                return emergencycontact;
            }
        }
        public EmergencyContact GetEmergencyContact(int emergencycontactId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select *
                            from EmergencyContact
                            where Id =@EmergencyContactId";
                var parameters = new
                {
                    EmergencyContactId = emergencycontactId
                };
                var emergencycontact = db.QueryFirst<EmergencyContact>(sql, parameters);
                return emergencycontact;

            }
        }

        public bool AddEmergencyContact(AddEmergencyContactCommand newEmergencyContact)
        {

            using (var db = new SqlConnection(_connectionString))
            {

                var sql = @"Insert INTO [EmergencyContact]
                                                 ([FirstName]
                                                  ,[LastName]
                                                  ,[Relationship]
                                                  ,[Phone])
                                            output inserted.*
                                               VALUES
                                                      (@firstname
                                                       ,@lastname
                                                       ,@relationship
                                                        ,@phone)";
               
                return db.Execute(sql, newEmergencyContact) == 1;
            }
        }

        public bool DeleteEmergencyContact(EmergencyContact emergencycontactToDelete, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE[dbo].[EmergencyContact]
                                   SET [FirstName] = null
                                       ,[LastName] = null
                                       ,[Relationship] = null
                                       ,[Phone] = null
                                       WHERE [Id] = @id";

                emergencycontactToDelete.Id = id;

                return connection.Execute(sql, emergencycontactToDelete) == 1;

            }
        }

        public bool UpdateEmergencyContact(EmergencyContact EmergencyContactToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"update [dbo].[EmergencyContact]
                                    SET [FirstName] = @firstname,
                                        [LastName] = @lastname,
                                        [Relationship] = @relationship,
                                        [Phone] = @phone
                               WHERE [id] = @id";

                EmergencyContactToUpdate.Id = id;

                return connection.Execute(sql, EmergencyContactToUpdate) == 1;




            }
        }
    }
}
