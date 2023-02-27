using _02.VillainNames;
using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();

            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();

            SqlCommand getMinionNamesCommand = new SqlCommand(SqlQueries.MinionNames, connection);
            SqlDataReader reader = getMinionNamesCommand.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                counter++;
                string name = reader["Name"].ToString();
                if (counter % 2 == 0)
                {
                    stack.Push(name);
                }
                else
                {
                    queue.Enqueue(name);
                }
            }

            while (stack.Any() && queue.Any())
            {
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(stack.Pop());
            }

            if (queue.Any())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}