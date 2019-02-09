using MVC_ActionLink_DiplomadoUASD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ActionLink_DiplomadoUASD.Controllers
{
    public class ClientesController : Controller
    {
        private static Practica41Entities _context = null;
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            List<ClientesModel> list = new List<ClientesModel>();
            using (_context = new Practica41Entities())
            {
                foreach (var item in _context.Clientes.Where(c => c.IdCliente > 0))
                {
                    list.Add(new ClientesModel {
                        ClienteID = item.IdCliente,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Cedula = item.Cedula,
                        Telefono = item.Telefono
                    });
                }
            }
            return View(list);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FormCollection collection)
        {
            using (_context = new Practica41Entities())
            {
                _context.Clientes.Add(new Cliente {
                    IdCliente = int.Parse(collection["Id"]),
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Cedula = collection["Cedula"],
                    Telefono = collection["Telefono"]
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Listado");
        }
    }
}