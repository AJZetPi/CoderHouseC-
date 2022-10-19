using PreEntrega_Proyecto;
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var listaUsuarios = new List<Usuario>();
        var listaProductos = new List<Producto>();
        var listaProductosVendidos = new List<ProductoVendido>();
        var listaVentas = new List<Venta>();


        SqlConnectionStringBuilder connectionbuilder = new();
        connectionbuilder.DataSource = "AJZET\\SQLEXPRESS";
        connectionbuilder.InitialCatalog = "SistemaGestion";
        connectionbuilder.IntegratedSecurity = true;
        var cs = connectionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM producto";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var product = new Producto();
                product.Id = Convert.ToInt32(reader.GetValue(0));
                product.Descripciones = reader.GetValue(1).ToString();
                product.Costo = Convert.ToDouble(reader.GetValue(2));
                product.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                product.Stock = Convert.ToInt32(reader.GetValue(4));
                product.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                listaProductos.Add(product);
            }

            Console.WriteLine("-----PRODUCTOS-----");
            foreach (var product in listaProductos)
            {
                Console.WriteLine("id = "+product.Id);
                Console.WriteLine("Descripciones = " + product.Descripciones);
                Console.WriteLine("Costo = " + product.Costo);
                Console.WriteLine("PrecioVenta = " + product.PrecioVenta);
                Console.WriteLine("Stock = " + product.Stock);
                Console.WriteLine("IdUsuario = " + product.IdUsuario);

                Console.WriteLine("------------------");
            }
            reader.Close();

            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "SELECT * FROM usuario";
            var reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {

                var user = new Usuario();
                user.Id = Convert.ToInt32(reader2.GetValue(0));
                user.Nombre = reader2.GetValue(1).ToString();
                user.Apellido = reader2.GetValue(2).ToString();
                user.NombreUsuario = reader2.GetValue(3).ToString();
                user.Contraseña = reader2.GetValue(4).ToString();
                user.Mail = reader2.GetValue(5).ToString();
                listaUsuarios.Add(user);
            }
            Console.WriteLine("-----USUARIOS-----");
            foreach (var user in listaUsuarios)
            {
                Console.WriteLine("id = " + user.Id);
                Console.WriteLine("Nombre = " + user.Nombre);
                Console.WriteLine("Apellido = " + user.Apellido);
                Console.WriteLine("NombreUsuario = " + user.NombreUsuario);
                Console.WriteLine("Contraseña = " + user.Contraseña);
                Console.WriteLine("Mail = " + user.Mail);

                Console.WriteLine("------------------");
            }
            reader2.Close();
            SqlCommand cmd3 = connection.CreateCommand();
            cmd3.CommandText = "SELECT * FROM productovendido";
            var reader3 = cmd3.ExecuteReader();

            while (reader3.Read())
            {

                var sellproduct = new ProductoVendido();
                sellproduct.Id = Convert.ToInt32(reader3.GetValue(0));
                sellproduct.Stock = Convert.ToInt32(reader3.GetValue(1));
                sellproduct.IdProducto = Convert.ToInt32(reader3.GetValue(2));
                sellproduct.IdVenta = Convert.ToInt32(reader3.GetValue(3)); 
                listaProductosVendidos.Add(sellproduct);
            }
            Console.WriteLine("-----Productos Vendidos-----");
            foreach (var sellproduct in listaProductosVendidos)
            {
                Console.WriteLine("id = " + sellproduct.Id);
                Console.WriteLine("Stock = " + sellproduct.Stock);
                Console.WriteLine("IdProducto = " + sellproduct.IdProducto);
                Console.WriteLine("IdVenta = " + sellproduct.IdVenta);
                

                Console.WriteLine("------------------");
            }
            reader3.Close();
            SqlCommand cmd4 = connection.CreateCommand();
            cmd4.CommandText = "SELECT * FROM venta";
            var reader4 = cmd4.ExecuteReader();

            while (reader4.Read())
            {

                var sell = new Venta();
                sell.Id = Convert.ToInt32(reader4.GetValue(0));
                sell.Comentarios = reader4.GetValue(1).ToString();
                
                listaVentas.Add(sell);
            }
            Console.WriteLine("-----Ventas-----");
            foreach (var sell in listaVentas)
            {
                Console.WriteLine("id = " + sell.Id);
                Console.WriteLine("Stock = " + sell.Comentarios);
                


                Console.WriteLine("------------------");
            }
            reader4.Close();
        }
    }
    
}