// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;

Console.WriteLine("DXP Console");

Console.WriteLine();

Console.WriteLine("Testing database connection....");

string connectionString = "Server=SCMBIEBERSTEIN;Database=DXP;User Id=dxp;Password=sql123;Encrypt=False";

SqlConnection connection = new SqlConnection(connectionString);

SqlCommand command = connection.CreateCommand();

connection.Open();

Console.WriteLine(connection.Database);

Console.WriteLine("OK");

Console.ReadLine();