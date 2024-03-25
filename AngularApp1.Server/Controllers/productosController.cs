using data.Data;
using Microsoft.AspNetCore.Mvc;
using AngularApp1.Server.Models.Respuesta;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static AngularApp1.Server.Models.Producto;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AngularApp1.Server.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ejemplo_prueba.Controllers
{
    [Route("/api/productos")]
    public class productoController : Controller
    {
        //Aqui inicia el metodo para obtener los productos
        [HttpGet]
        public List<productosObtener> Get()
        {
            return productoData.Obtener();
        }

        [HttpGet("[action]")]
        public List<obtenerTipoProductoId> busquedaNombreProducto(int id)
        {
            Console.WriteLine(id);
            return productoData.busquedaNombreProducto(new obtenerTipoProductoId
            {
                TipoProducto_Id = id
            });
        }

        [HttpGet("[action]")]
        public List<obtenerTipoProductoId> obtenerTipoProductoId()
        {
            return productoData.obtenerTipoProductoId();
        }
        //Aqui inicia el metodo para Agregar los productos
        [HttpPost("[action]")]
        public ActionResult<Respuesta> agregar([FromBody] productoRegistrar model)
        {
            Respuesta oR = new Respuesta();
            List<productosObtener> ultimoId = productoData.ObtenerUltimoProducto();
            try
            {
                    int idProducto = ultimoId[0].IdProductos;

                    bool resultado = productoData.agregarProductos(new productoRegistrar
                    {
                        nombreProductos = model.nombreProductos,
                        Precio = model.Precio,
                        Descripcion = model.Descripcion,
                        TipoProducto_Id = model.TipoProducto_Id,
                        Existencia = model.Existencia
                    });
                oR.Success = 1;
            }
            catch (Exception ex)
            {
                oR.Success = 0;
                oR.Messagge = ex.Message;
            }
            return oR;
        }
        //Aqui inicia el metodo para la busqueda de productos
        
    }
    [Route("api/busquedaProductos")]
    //Este endPoint se ejecuta y manda los datos a la pantalla principal del Modificar
    public class busquedaController : Controller
    {
        [HttpGet]
        public List<productosObtener> busquedaProductos( int id, string valor)
        {
            try
            {
                return productoData.busquedaProducto(new productosObtener
                {
                    IdProductos = id,
                    nombreProductos = valor
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                return new List<productosObtener>();
            }
            
        }
    }

    [Route("api/obtenerDatos")]
    public class obtenerDatosController : Controller
    {
        [HttpGet]
        public List<productosObtener> obtenerDatos(int id)
        {
            try
            {
                return productoData.obtenerDatosProducto(new productosObtener
                {
                    IdProductos = id
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                return new List<productosObtener>();
            }

        }
    }

    [Route("api/")]
    //Este endPoint se ejecuta al seleccionar el boton Eliminar y manda los datos a la pantalla principal del Modificar
    public class eliminarProductoController : Controller
    {
        [HttpDelete("eliminarProducto")]
        public List<productosObtener> delete(int id)
        {
            try
            {
                return productoData.eliminarProducto(new productosObtener
                {
                    IdProductos = id
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la búsqueda: {ex.Message}");
                return new List<productosObtener>();
            }

        }
    }
    [Route("api/")]
    public class modificarProductoController : Controller
    {
        [HttpPut("modificarProducto")]
        public IActionResult ModificarProducto(int id, [FromBody] productosObtener productoModificar)
        {
            try
            {
                productoData.modificarProducto(new productosObtener
                {
                    IdProductos = id,
                    nombreProductos = productoModificar.nombreProductos,
                    descripcion = productoModificar.descripcion,
                    Precio = productoModificar.Precio,
                    Existencia = productoModificar.Existencia,
                    TipoProducto_Id = productoModificar.TipoProducto_Id
                });
                return Ok(new { mensaje = "Producto modificado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al modificar el producto", error = ex.Message });
            }
        }

    }
}