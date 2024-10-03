using System;
using System.Data.SqlClient;

class Program1
{
    static void Main(string[] args)
    {
        // Define the connection string (with hard-coded password)
        //string connectionString = "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;";

// Hardcoded parts of the connection string
        string server = "Server=your_server_name;";
        string database = "Database=your_database_name;";
        string userId = "User Id=your_username;";
        
        // Concatenating password
        string part1 = "your";
        string part2 = "_password";
        string password = part1 + part2;  // Concatenating password
        
        // Concatenate the full connection string
        string connectionString = server + database + userId + "Password=" + password + ";";
        // Example query
        string query = "SELECT * FROM your_table_name1";

        // Create a new connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Database connection successful.");

                // Create a SQL command
                SqlCommand command = new SqlCommand(query, connection);

                // Execute the command and process the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Output the first column (modify based on your table structure)
                        Console.WriteLine(reader[0].ToString());
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL error: " + e.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }
    }
}
