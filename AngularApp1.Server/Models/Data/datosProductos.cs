using Ejemplo_prueba.Models;
using Ejemplo_prueba.Models.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using static AngularApp1.Server.Models.Producto;

namespace data.Data
{
    public class productoData
    {
        //Metodo para obtener los productos de la BD
        public static List<productos> Obtener()
        {
            
            List<productos> oListaProducto = new List<productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure de la api que se va a consumir
                SqlCommand cmd = new SqlCommand("Obtener_Productos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new productos()
                            {
                                IdProductos = Convert.ToInt32(dr["Id"]),
                                nombreProductos = (string)dr["NombreProducto"],
                                nombreTipoProducto = (string)dr["nombreTipoProducto"],
                                descripcion = (string)dr["DescripcionProducto"],
                                Existencia = Convert.ToInt32(dr["Existencia"]),
                                Precio = Convert.ToInt32(dr["Precio"])
                            });
                        }

                    }
                    
                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion 7: " + ex);
                    Console.WriteLine(ex);
                    return oListaProducto;
                }
            }
        }

        ////Metodo para Regristrar productos en la BD
        public static bool registrarProductos ()
        {
            return true;
        }
        /*public static bool Registrar(Result oResult)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Crear_Productos", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", oResult.Id);
                cmd.Parameters.AddWithValue("@Mensaje", oResult.Mensaje);
                cmd.Parameters.AddWithValue("@Datos", oResult.Datos);
                cmd.Parameters.AddWithValue("@EsValido", oResult.EsValido);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }*/
    }
}
