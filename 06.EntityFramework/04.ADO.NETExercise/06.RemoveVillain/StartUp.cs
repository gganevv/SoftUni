using _02.VillainNames;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain;

public class StartUp
{
    static void Main(string[] args)
    {
        int villainId = int.Parse(Console.ReadLine());

        SqlConnection connection = new SqlConnection(Config.ConnectionString);
        connection.Open();

        SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainById, connection);
        getVillainNameCommand.Parameters.AddWithValue("@id", villainId);
        string? villainName = (string?)getVillainNameCommand.ExecuteScalar();

        if (villainName == null)
        {
            Console.WriteLine("No such villain was found.");
        }
        else
        {
            SqlCommand deleteMinionsCommand = new SqlCommand(SqlQueries.DeleteMinions, connection);
            deleteMinionsCommand.Parameters.AddWithValue("@villainId", villainId);
            int relesedMinions = deleteMinionsCommand.ExecuteNonQuery();

            SqlCommand deleteVillianCommand = new SqlCommand(SqlQueries.DeleteVillian, connection);
            deleteVillianCommand.Parameters.AddWithValue("@villainId", villainId);
            deleteVillianCommand.ExecuteNonQuery();
            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{relesedMinions} minions were released.");
        }
    }
}