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

    }
}
