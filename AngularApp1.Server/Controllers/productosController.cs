using data.Data;
using Microsoft.AspNetCore.Mvc;
using AngularApp1.Server.Models.Respuesta;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static AngularApp1.Server.Models.Producto;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                //Console.WriteLine(ultimoId);
                //Console.WriteLine(model);

                    int idProducto = ultimoId[0].IdProductos;

                    bool resultado = productoData.agregarProductos(new productoRegistrar
                    {
                        IdProductos = idProducto,
                        nombreProducto = model.nombreProducto,
                        Precio = model.Precio,
                        Descripcion = model.Descripcion,
                        TipoProducto_Id = model.TipoProducto_Id,
                        Existencia = model.Existencia
                    });
                

                /*bool resultado = productoData.agregarProductos(new Respuesta
                {
                    Success = model.nombreProductos, // Ajusta según las propiedades reales de tu modelo
                    Messagge = model.Mensaje, // Ajusta según las propiedades reales de tu modelo
                    Data = model.Datos // Ajusta según las propiedades reales de tu modelo
                });*/
                //productoData.agregarProductos();
                oR.Success = 1;
            }
            catch (Exception ex)
            {
                oR.Success = 0;
                oR.Messagge = ex.Message;
            }
            return oR;
        }
    }
}