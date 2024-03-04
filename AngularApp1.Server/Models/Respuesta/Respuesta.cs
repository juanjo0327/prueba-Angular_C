using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp1.Server.Models.Respuesta
{
    public class Respuesta
    {
        public int Success { get; set; }
        public string Messagge {  get; set; }
        public object Data {  get; set; }  
    }
}
