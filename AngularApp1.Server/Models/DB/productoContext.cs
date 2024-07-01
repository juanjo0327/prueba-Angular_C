using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_prueba.Models.DB;

public partial class Conexion
{
    //Conexion a la BD
    public static string rutaConexion = "Data Source=230465L90168233\\SQLEXPRESS;Initial Catalog=productos;Integrated Security=True;TrustServerCertificate=true;";
}