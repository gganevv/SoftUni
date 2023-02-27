using _02.VillainNames;
using _08.IncreaseMinionAge;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure;

public class StartUp
{
    static void Main(string[] args)
    {
        SqlConnection connection = new SqlConnection(Config.ConnectionString);
        connection.Open();

        int minionId = int.Parse(Console.ReadLine());

        SqlCommand increaseAgeCommand = new SqlCommand(SqlQueries.ExecuteSP, connection);
        increaseAgeCommand.Parameters.AddWithValue("@Id", minionId);
        increaseAgeCommand.ExecuteNonQuery();

        SqlCommand printMinionInfo = new SqlCommand(SqlQueries.SelectMinionNameAgeById, connection);
        printMinionInfo.Parameters.AddWithValue("@Id", minionId);

        string name = string.Empty;
        int age = 0;

        SqlDataReader reader = printMinionInfo.ExecuteReader();
        while (reader.Read())
        {
            name = reader["Name"].ToString();
            age = (int)reader["Age"];
        }

        Minion minion = new Minion(name, age);
        Console.WriteLine(minion);
    }
}