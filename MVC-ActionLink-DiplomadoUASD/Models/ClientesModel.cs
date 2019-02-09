using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ActionLink_DiplomadoUASD.Models
{
    public class ClientesModel
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
    }
}