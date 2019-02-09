using MVC_ActionLink_DiplomadoUASD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ActionLink_DiplomadoUASD.Controllers
{
    public class ProveedoresController : Controller
    {
        private static Practica41Entities _context = null;
        // GET: Proveedores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            List<ProveedoresModel> list = new List<ProveedoresModel>();
            using (_context = new Practica41Entities())
            {
                foreach (var item in _context.Proveedors.Where(c => c.IdProveedor > 0))
                {
                    list.Add(new ProveedoresModel
                    {
                        ProveedorID = item.IdProveedor,
                        Nombre = item.Nombre,
                        RNC = item.RNC,
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
                _context.Proveedors.Add(new Proveedor
                {
                    IdProveedor = int.Parse(collection["Id"]),
                    Nombre = collection["Nombre"],
                    RNC = collection["RNC"],
                    Telefono = collection["Telefono"]
                });
                _context.SaveChanges();
            }
            return RedirectToAction("Listado");
        }
    }
}