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
            cmd.CommandText = "SELECT * FROM productovendido";
            var reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                Console.WriteLine("Producto Vendido "+x++);
                Console.WriteLine(reader.GetInt64(0));
                Console.WriteLine(reader.GetInt32(1));
                Console.WriteLine(reader.GetInt64(2));
                Console.WriteLine(reader.GetInt64(3));

            }
            reader.Close();
        }
    }

}