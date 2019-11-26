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
    public class ClubRepository
    {
        string _connectionString = "Server=localhost;Database=FightAndFeast;Trusted_Connection=True;";

        public List<Club> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var clubs = connection.Query<Club>("Select * from Club");

                return clubs.AsList();
            }
        }

        public Club GetClub(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"select * from Club where Club.Name = @clubName";

                var parameters = new
                {
                    clubName = name
                };

                var club = connection.QueryFirst<Club>(sql, parameters);

                return club;
            }
        }

        public bool AddClub(AddClubCommand newClub)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var addClub = @"INSERT INTO [dbo].[Club]
	                                ([Name]
	                                ,[Address]
	                                ,[Phone]
	                                ,[Capacity]
	                                ,[Description])
                                 output inserted.*
                                 VALUES
	                                (@name
                                    ,@address
                                    ,@phone
                                    ,@capacity
                                    ,@description)";

                var parameters = new
                {
                    name = newClub.Name,
                    address = newClub.Address,
                    phone = newClub.Phone,
                    capacity = newClub.Capacity,
                    description = newClub.Description
                };

                var rowsAffected = connection.Execute(addClub, parameters);
                return rowsAffected == 1;
            }
        }

        public bool UpdateClub(Club clubToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Club]
	                            SET [Name] = @name
                                    ,[Address] = @address
	                                ,[Phone] = @phone
	                                ,[Capacity] = @capacity
	                                ,[Description] = @description
	                        WHERE [Id] = @id";

                clubToUpdate.Id = id;

                return connection.Execute(sql, clubToUpdate) == 1;
            }
        }
    }
}
