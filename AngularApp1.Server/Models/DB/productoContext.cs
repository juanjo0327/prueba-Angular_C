using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_prueba.Models.DB;

public partial class Conexion
{
    public static string rutaConexion = "Data Source=230556L90168233\\SQLEXPRESS02;Initial Catalog=productos;Integrated Security=True;TrustServerCertificate=true;";
}