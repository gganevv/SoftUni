using _02.VillainNames;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainCommand = new SqlCommand(SqlQueries.GetVillainById, connection);
            getVillainCommand.Parameters.AddWithValue("@Id", villainId);

            object villainNameObj = getVillainCommand.ExecuteScalar();
            if (villainNameObj != null)
            {
                Console.WriteLine($"Villain: {villainNameObj.ToString()}");
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            SqlCommand getMinionsByVillainIdCommand = new SqlCommand(SqlQueries.GetMinionsByVillainId, connection);
            getMinionsByVillainIdCommand.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader reader = getMinionsByVillainIdCommand.ExecuteReader();

            bool hasMinions = false;
            while (reader.Read())
            {
                hasMinions = true;
                long RowNum = (long)reader["RowNum"];
                string minionName = reader["Name"].ToString();
                int minionAge = (int)reader["Age"];
                Console.WriteLine($"{RowNum}. {minionName} {minionAge}");
            }
            if (!hasMinions)
            {
                Console.WriteLine("(no minions)");
            }

        }
    }
}