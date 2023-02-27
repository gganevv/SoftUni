using _02.VillainNames;
using Microsoft.Data.SqlClient;

namespace _08.IncreaseMinionAge;

public class StartUp
{
    static void Main(string[] args)
    {
        SqlConnection connection = new SqlConnection(Config.ConnectionString);
        connection.Open();
        int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < ids.Length; i++)
        {
            int id = ids[i];
            SqlCommand updateMinionsCommand = new SqlCommand(SqlQueries.UpdateMinions, connection);
            updateMinionsCommand.Parameters.AddWithValue("@Id", id);
            updateMinionsCommand.ExecuteNonQuery();
        }

        SqlCommand readAllMinionsCommand = new SqlCommand(SqlQueries.SelectMinionsNameAndAge, connection);
        List<Minion> minions = new List<Minion>();

        SqlDataReader reader = readAllMinionsCommand.ExecuteReader();
        while (reader.Read())
        {
            string name = reader["Name"].ToString();
            int age = (int)reader["Age"];
            minions.Add(new Minion(name, age));
        }

        foreach (var minion in minions)
        {
            Console.WriteLine(minion);
        }
    }
}