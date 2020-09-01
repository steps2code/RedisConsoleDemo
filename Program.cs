using StackExchange.Redis;
using System;

namespace RedisConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Connect to redis server.
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect("localhost");
            //Step 2: Get the reference of the redis database using the redis connection.
            IDatabase redisDbConnection = redisConnection.GetDatabase();
            //Step 3: Execute the command against the database.

            Console.WriteLine("String DatType Example:");
            string key = "name", value = "Yash";
            redisDbConnection.StringSet(key, value);

            var keyValue = redisDbConnection.StringGet("name");
            Console.WriteLine("Key:{0} Value:{1}", key, value);

            if (redisDbConnection.KeyDelete(key))
                Console.WriteLine("The key is deleted.");

            if (redisDbConnection.KeyExists(key))
                Console.WriteLine("Key:{0} Value:{1}", key, value);
            else
                Console.WriteLine("The key is not present in the system.");

            Console.WriteLine("Hash DataType Example:");
            HashEntry[] countryMasterObj = {
            new HashEntry("Code", "IND"),
            new HashEntry("Language", "Hindi"),
            new HashEntry("Name", "INDIA")
          };

            redisDbConnection.HashSet("CountryMasterKey", countryMasterObj);
            var allHash = redisDbConnection.HashGetAll("CountryMasterKey");
            foreach (var item in allHash)
            {
                Console.WriteLine(string.Format("key : {0}, value : {1}", item.Name, item.Value));
            }

            Console.Read();
        }
    }

}
