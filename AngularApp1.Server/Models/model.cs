﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AngularApp1.Server.Models
{
    public class Producto
    {
        public class productosObtener
        {
            public int IdProductos { get; set; }
            public string nombreProductos {get; set;}
            public string nombreTipoProducto { get; set; }
            public string descripcion { get; set; }
            public int Existencia { get; set; } 
            public int Precio { get; set;}
            public int TipoProducto_Id { get; set; }
        }

        public class productoRegistrar
        {
            public int IdProductos { get; set; }
            public string nombreProductos { get; set; }
            public int Precio { get; set; }
            public string Descripcion { get; set; }
            public int TipoProducto_Id { get; set; }
            public int Existencia { get; set; }
            
        }

        public class obtenerTipoProductoId
        {
            public int TipoProducto_Id { get; set; }
            public string nombreTipoProducto { get; set; }
        }
    }
}
