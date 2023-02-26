using Util;
using Microsoft.Data.SqlClient;
using _02.VillainNames;
using Microsoft.Data.SqlClient.DataClassification;

namespace _04.AddMinion
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();

            string[] minionArgs = Console.ReadLine().Split();
            string[] villainArgs = Console.ReadLine().Split();

            string minionName = minionArgs[1];
            int minionAge = int.Parse(minionArgs[2]);
            string townName = minionArgs[3];
            string villainName = villainArgs[1];
            
            int? villainId = GetVillianId(connection, villainName);
            int? townId = GetTownId(connection, townName);

            int? minionId = GetMinionId(connection, minionName, minionAge, townId);

            SqlCommand insertMinionVillianCommand = new SqlCommand(SqlQueries.InsertMinionVillian, connection);
            insertMinionVillianCommand.Parameters.AddWithValue("@minionId", minionId);
            insertMinionVillianCommand.Parameters.AddWithValue("@villainId", villainId);
            insertMinionVillianCommand.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int? GetMinionId(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            SqlCommand getMinionIdCommand = new SqlCommand(SqlQueries.GetMinionId, connection);
            getMinionIdCommand.Parameters.AddWithValue("@name", minionName);
            int? minionId = (int?)getMinionIdCommand.ExecuteScalar();
            if (minionId == null)
            {
                SqlCommand insertMinionCommand = new SqlCommand(SqlQueries.InsertMinion, connection);
                insertMinionCommand.Parameters.AddWithValue("@name", minionName);
                insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                insertMinionCommand.Parameters.AddWithValue("@townId", townId);
                insertMinionCommand.ExecuteNonQuery();
            }

            minionId = (int?)getMinionIdCommand.ExecuteScalar();

            return minionId;
        }

        private static int? GetTownId(SqlConnection connection, string townName)
        {
            SqlCommand searchTownCommand = new SqlCommand(SqlQueries.GetTownByName, connection);
            searchTownCommand.Parameters.AddWithValue("@townName", townName);
            int? townId = (int?)searchTownCommand.ExecuteScalar();
            if (townId == null)
            {
                townId = InsertTown(connection, townName, searchTownCommand);
            }

            return townId;
        }

        private static int? InsertTown(SqlConnection connection, string townName, SqlCommand searchTownCommand)
        {
            SqlCommand insertTownCommand = new SqlCommand(SqlQueries.InsertTown, connection);
            insertTownCommand.Parameters.AddWithValue("@townName", townName);
            insertTownCommand.ExecuteNonQuery();
            int? townId = (int?)GetTownId(connection, townName);
            Console.WriteLine($"Town {townName} was added to the database.");

            return townId;
        }

        private static int? GetVillianId(SqlConnection connection, string villainName)
        {
            SqlCommand searchVillianCommand = new SqlCommand(SqlQueries.GetVillainByNane, connection);
            searchVillianCommand.Parameters.AddWithValue("@Name", villainName);
            int? villainId = (int?)searchVillianCommand.ExecuteScalar();
            if (villainId == null)
            {
                villainId = InsertVillian(connection, villainName, searchVillianCommand);
            }
            

            return villainId;
        }

        private static int? InsertVillian(SqlConnection connection, string villainName, SqlCommand searchVillianCommand)
        {
            SqlCommand insertVillianCommand = new SqlCommand(SqlQueries.InsertVillian, connection);
            insertVillianCommand.Parameters.AddWithValue("@villainName", villainName);
            insertVillianCommand.ExecuteNonQuery();
            int? villainId = (int?)searchVillianCommand.ExecuteScalar();
            Console.WriteLine($"Villain {villainName} was added to the database.");
            return villainId;
        }
    }
}