using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega_Proyecto
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }

        public double Costo { get; set; }

        public double  PrecioVenta  { get; set; }   
        public int Stock { get; set; }

        public int IdUsuario { get; set; } 
        public Producto()
        {
            Id = 0;
            Descripciones = String.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
    }
}
