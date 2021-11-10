using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Data;

using SistemaWebVuelos.Models;


namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        private VueloDBContext context = new VueloDBContext();
      
        public ActionResult Index()
        {
            var vuelos = context.Vuelos.ToList();

            return View("Index", vuelos);

        }

        [HttpGet]
        public ActionResult Create()
        {
            Vuelo vue = new Vuelo();

            return View("Create", vue);
        }


        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", vuelo);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }

            return HttpNotFound();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo == null)
                return HttpNotFound();

            return View("Delete", vuelo);
        }




        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo= context.Vuelos.Find(id);
            if (vuelo == null)
                return HttpNotFound();

            context.Vuelos.Remove(vuelo);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult BuscarPorDestino(string destino)
        {
            if (destino == null)
            {
                return RedirectToAction("Index");
            
            }
            var vuelo = (from v in context.Vuelos
                         where v.Destino == destino
                         select v).ToList();
            return View("Index", vuelo);
        }






    }
}