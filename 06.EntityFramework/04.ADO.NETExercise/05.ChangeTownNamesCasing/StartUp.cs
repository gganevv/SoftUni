using _02.VillainNames;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();

            string countryName = Console.ReadLine();

            SqlCommand updateTownsNamesCommand = new SqlCommand(SqlQueries.UpdateTownNames, connection);
            updateTownsNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            int modifiedTowns = updateTownsNamesCommand.ExecuteNonQuery();
            if (modifiedTowns > 0)
            {
                Console.WriteLine($"{modifiedTowns} town names were affected.");
                ShowModifiedTowns(connection, countryName);
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }
        }

        private static void ShowModifiedTowns(SqlConnection connection, string? countryName)
        {
            List<string> towns = new List<string>();
            SqlCommand showTownNamesCommand = new SqlCommand(SqlQueries.SelectTownsFromCounty, connection);
            showTownNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader reader = showTownNamesCommand.ExecuteReader();
            while (reader.Read())
            {
                towns.Add(reader["Name"].ToString());
            }

            Console.WriteLine(string.Join(", ", towns));
        }
    }
}