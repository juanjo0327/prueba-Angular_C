﻿using AngularApp1.Server.Models.Respuesta;
using Ejemplo_prueba.Models;
using Ejemplo_prueba.Models.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using static AngularApp1.Server.Models.Producto;

namespace data.Data
{
    public class productoData
    {
        public string connectionString = null;

        public productoData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Metodo Para abrir conexion
        public SqlConnection abrirConexion()
        {
            SqlConnection oConexion = new SqlConnection(connectionString);
            try
            {
                oConexion.Open();
                return oConexion;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                return null;

            }

        }
        //Metodo Para cerrar conexion
        /*public void CerrarConexion(SqlConnection conexion)
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
            }
        }*/

        public static List<productosObtener> ObtenerUltimoProducto()
        {
            List<productosObtener> oListaProducto = new List<productosObtener>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure de la api que se va a consumir
                SqlCommand cmd = new SqlCommand("obtenerUltimoCodigo", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new productosObtener()
                            {
                                IdProductos = Convert.ToInt32(dr["IdProducto"]),
                            });
                        }

                    }
                    Console.WriteLine(oListaProducto);
                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion del ObtenerUltimoProducto: " + ex);
                    return oListaProducto;
                }
            }
        }

        //Metodo para obtener los productos de la BD
        public static List<productosObtener> Obtener()
        {
            List<productosObtener> oListaProducto = new List<productosObtener>();
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
                            oListaProducto.Add(new productosObtener()
                            {
                                IdProductos = Convert.ToInt32(dr["IdProducto"]),
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
                    Console.WriteLine("Entro a la excepcion del Obtener: " + ex);
                    return oListaProducto;
                }
            }
        }

        public static List<obtenerTipoProductoId> busquedaNombreProducto(obtenerTipoProductoId obtenertipoProductoId)
        {
            List<obtenerTipoProductoId> oListaProducto = new List<obtenerTipoProductoId>();
            string query = "SELECT * FROM TiposProductos WHERE IdTiposProductos = " + obtenertipoProductoId.TipoProducto_Id;
            try
            {
                productoData data = new productoData(Conexion.rutaConexion);
                data.abrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, data.abrirConexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oListaProducto.Add(new obtenerTipoProductoId()
                            {   
                                TipoProducto_Id = Convert.ToInt32(reader["IdTiposProductos"]),
                                nombreTipoProducto = (string)reader["nombreTipoProducto"]
                            });
                        }
                    }
                }
                return oListaProducto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entro a la excepciion del busquedaNombreProducto:");
                Console.WriteLine(ex);
                return oListaProducto;
            }
        }
        public static List<obtenerTipoProductoId> obtenerTipoProductoId()
        {
            List<obtenerTipoProductoId> oListaProducto = new List<obtenerTipoProductoId>();
            string query = "SELECT IdTiposProductos, nombreTipoProducto FROM TiposProductos";
            try
            {
                productoData data = new productoData(Conexion.rutaConexion);
                data.abrirConexion();
                using (SqlCommand cmd = new SqlCommand(query, data.abrirConexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            oListaProducto.Add(new obtenerTipoProductoId()
                            {
                                TipoProducto_Id = Convert.ToInt32(reader["IdTiposProductos"]),
                                nombreTipoProducto = (string)reader["nombreTipoProducto"]
                            });
                        }
                    }
                }
                return oListaProducto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entro a la excepciion del obtenerTipoProductoId:");
                Console.WriteLine(ex);
                return oListaProducto;
            }
        }

        //Metodo para Regristrar productos en la BD
        public static bool agregarProductos(productoRegistrar productoRegistrar)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Crear_Productos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreProducto", productoRegistrar.nombreProductos);
                cmd.Parameters.AddWithValue("@DescripcionProducto", productoRegistrar.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", productoRegistrar.Precio);
                cmd.Parameters.AddWithValue("@Existencia", productoRegistrar.Existencia);
                cmd.Parameters.AddWithValue("@TipoProducto_Id", productoRegistrar.TipoProducto_Id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Entro a la excepcion del agregarProductos:", e);
                    Console.WriteLine(e);
                    return false;
                }
            }
        }

        //Metodo para Regristrar productos en la BD
        public static List<productosObtener> busquedaProducto(productosObtener productosObtener)
        {
            List<productosObtener> oListaProducto = new List<productosObtener>();
            if(productosObtener.nombreProductos == null)
            {
                productosObtener.nombreProductos = "0";
            }
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure que se va a consumir
                SqlCommand cmd = new SqlCommand("Busqueda_Productos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", productosObtener.IdProductos);
                cmd.Parameters.AddWithValue("@nombreProducto", productosObtener.nombreProductos);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    //if(productosObtener.nombreProductos != 0 && )
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new productosObtener()
                            {
                                IdProductos = Convert.ToInt32(dr["IdProducto"]),
                                nombreProductos = (string)dr["NombreProducto"],
                                descripcion = (string)dr["DescripcionProducto"],
                                Existencia = Convert.ToInt32(dr["Existencia"]),
                                Precio = Convert.ToInt32(dr["Precio"]),
                                TipoProducto_Id = Convert.ToInt32(dr["IdTiposProductos"]),
                                nombreTipoProducto = (string)dr["nombreTipoProducto"]
                            });
                        }
                    }
                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion del busquedaProducto:" + ex);
                    Console.WriteLine(ex);

                    return oListaProducto;
                }
            }
        }

        public static List<productosObtener> obtenerDatosProducto(productosObtener productosObtener)
        {
            List<productosObtener> oListaProducto = new List<productosObtener>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure que se va a consumir
                SqlCommand cmd = new SqlCommand("obtenerDatosProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", productosObtener.IdProductos);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new productosObtener()
                            {
                                IdProductos = Convert.ToInt32(dr["IdProducto"]),
                                nombreProductos = (string)dr["NombreProducto"],
                                descripcion = (string)dr["DescripcionProducto"],
                                Existencia = Convert.ToInt32(dr["Existencia"]),
                                Precio = Convert.ToInt32(dr["Precio"]),
                                TipoProducto_Id = Convert.ToInt32(dr["IdTiposProductos"]),
                                nombreTipoProducto = (string)dr["nombreTipoProducto"]
                            });
                        }
                    }
                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion del busquedaProducto:" + ex);
                    Console.WriteLine(ex);
                    return oListaProducto;
                }
            }
        }

        public static List<productosObtener> eliminarProducto(productosObtener productosObtener)
        {
            List<productosObtener> oListaProducto = new List<productosObtener>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure que se va a consumir
                SqlCommand cmd = new SqlCommand("eliminarProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", productosObtener.IdProductos);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaProducto.Add(new productosObtener()
                            {
                                IdProductos = Convert.ToInt32(dr["IdProducto"]),
                                nombreProductos = (string)dr["NombreProducto"],
                                descripcion = (string)dr["DescripcionProducto"],
                                Existencia = Convert.ToInt32(dr["Existencia"]),
                                Precio = Convert.ToInt32(dr["Precio"]),
                                TipoProducto_Id = Convert.ToInt32(dr["IdTiposProductos"]),
                                nombreTipoProducto = (string)dr["nombreTipoProducto"]
                                
                            });
                        }
                    }
                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion del busquedaProducto:" + ex);
                    Console.WriteLine(ex);
                    return oListaProducto;
                }
            }
        }

        public static bool modificarProducto(productosObtener productosObtener)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                //Stored Procedure que se va a consumir
                SqlCommand cmd = new SqlCommand("modificarProductos", oConexion);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", productosObtener.IdProductos);
                cmd.Parameters.AddWithValue("@nombreProducto", productosObtener.nombreProductos);
                cmd.Parameters.AddWithValue("@descripcionProducto", productosObtener.descripcion);
                cmd.Parameters.AddWithValue("@precio", productosObtener.Precio);
                cmd.Parameters.AddWithValue("@existencia", productosObtener.Existencia);
                cmd.Parameters.AddWithValue("@idtiposProductos", productosObtener.TipoProducto_Id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Entro try del datosProductos al modificarProducto");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entro a la excepcion del busquedaProducto:" + ex);
                    return false;
                }
            }
        }
    }
}