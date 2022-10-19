// See https://using System.Data;
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
            Console.WriteLine("Escribe el nombre de usuario");
            string nombreusuario = Console.ReadLine();
            Console.WriteLine("Escribe la contraseña");
            string contraseña = Console.ReadLine();
            cmd.CommandText = $"SELECT * FROM Usuario  WHERE NombreUsuario = '{nombreusuario}' AND Contraseña = '{contraseña}'";
            var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                if (reader.GetInt64(0) != 0) {
                    Console.WriteLine("Inicio de sesión ");
                    Console.WriteLine(reader.GetInt64(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(2));
                    Console.WriteLine(reader.GetString(3));
                    Console.WriteLine(reader.GetString(5));
                }
         

            }
           
            reader.Close();
        }
    }

}