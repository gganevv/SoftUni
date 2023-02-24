using Util;
using Microsoft.Data.SqlClient;
using _02.VillainNames;

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


        }
    }
}