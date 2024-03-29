﻿using Microsoft.Data.SqlClient;
using Util;

namespace _02.VillainNames;

public class StartUp
{
    static void Main()
    {
        SqlConnection connection = new SqlConnection(Config.ConnectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(SqlQueries.GetAllVillians, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string villainName = reader["Name"].ToString();
            int numberOfMinions = (int)reader["MinionsCount"];
            Console.WriteLine($"{villainName} - {numberOfMinions}");
        }

    }
}