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
                        nombreProducto = model.nombreProducto,
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
        [HttpPost("[action]")]
        public List<productosObtener> eliminarProducto([FromBody] int id)
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
}