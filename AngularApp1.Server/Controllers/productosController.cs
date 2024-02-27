using data.Data;
using Ejemplo_prueba.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using static AngularApp1.Server.Models.Producto;

namespace Ejemplo_prueba.Controllers
{
    [Route("/api/productos")]
    public class productoController : Controller
    {
        [HttpGet]
        //Aqui inicia el metodo para obtener los productos
        public List<productos> Get()
        {
            return productoData.Obtener();
        }
    }
}