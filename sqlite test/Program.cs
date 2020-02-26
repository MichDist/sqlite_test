using System;
using System.Data.SQLite;

namespace SQLite

{

    class Program
    {
        static void Main(string[] args)
        {
            // Test version of SQLite DB
            // Connection string for in-memory database
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            var con = new SQLiteConnection(cs);

            con.Open();

            var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();


            Console.WriteLine($"SQLite version: {version}");

            con.Close();

            // Create table and fill it with data
            string constr = @"URI=file:C:\Users\midistle\sqlite_test\test.db";

            var connection = new SQLiteConnection(constr);
            connection.Open();

            //var command = new SQLiteCommand(connection);
            /*
            command.CommandText = "DROP TABLE IF EXISTS cars";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY,
                                    name TEXT, 
                                    price INT)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO cars(name, price) VALUES ('Audi', 52642)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO cars(name, price) VALUES ('Mercedes', 57127)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO cars(name, price) VALUES ('Skoda', 9000)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO cars(name, price) VALUES ('Volvo', 29000)";
            command.ExecuteNonQuery();
            */
            // Insert with prepared statements
            /*command.CommandText = "INSERT INTO cars(name, price) VALUES(@name, @price)";

            command.Parameters.AddWithValue("@name", "BMW");
            command.Parameters.AddWithValue("@price", "36600");
            command.Prepare();

            command.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("Transaction finished");
            */
            // Read data
            string statement = "SELECT * FROM cars";

            var command = new SQLiteCommand(statement, connection);
            SQLiteDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}");
            }

            Console.ReadKey();
        }
    }
}
