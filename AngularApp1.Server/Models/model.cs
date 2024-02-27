using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AngularApp1.Server.Models
{
    public class Producto
    {
        public class productos
        {
            public int IdProductos { get; set; }
            public string nombreProductos { get; set;}
            public int tipoProducto_Id { get; set; }
            public string descripcion { get; set; }
            public int Existencia { get; set; } 
        }
    }
}
