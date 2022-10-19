using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        SqlConnectionStringBuilder connectionbuilder = new();
        connectionbuilder.DataSource = "AJZET\\SQLEXPRESS";
        connectionbuilder.InitialCatalog = "SistemaGestion";
        connectionbuilder.IntegratedSecurity = true;
        var cs = connectionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM venta";
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                Console.WriteLine("Venta " + (x = x + 1));
                Console.WriteLine();
                Console.WriteLine(reader.GetInt64(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine();

            }
            reader.Close();
        }
    }

}