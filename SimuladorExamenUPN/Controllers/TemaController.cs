using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using SimuladorExamenUPN.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class TemaController : Controller
    {
        
        public ITemaService service;
        public TemaController()
        {
      
            service = new TemaService();
        }
        public TemaController(ITemaService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ViewResult Index(string criterio)
        {

            var temas = service.GetTemaAsqueryable(criterio);

            ViewBag.Criterio = criterio;
            return View(temas);
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = service.GetCategoria();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost]
        public ActionResult Crear(Tema tema,List<int> Ids)
        {

            ViewBag.Categorias = service.GetCategoria();           

            if (ModelState.IsValid == true)
            {

                service.AddCategoria(tema);
               

                foreach (var categoriaid in Ids)
                {
                   var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                    service.AddTemaCategoria(temaCategoria);
                    
                }
                return RedirectToAction("Index");
            }

            else
            {
                return View(tema);
            }
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {

            Tema tema = service.GetTemasWhere(id);
            
                      
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {      
            if (ModelState.IsValid == true)
            {
                service.Editar(tema);
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            service.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}