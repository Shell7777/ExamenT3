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
    public class PreguntaController : Controller
    {
      //  private SimuladorContext context;
        IPreguntaService service;

        public PreguntaController()
        {
           //context = new SimuladorContext();
            service = new PreguntaService();
        }
        public PreguntaController(IPreguntaService service) {
            this.service = service;        
        }
        [HttpGet]
        public ActionResult Index(int temaId)
        {
            var tema = service.getTema(temaId);

            return View(tema);
        }

        [HttpGet]
        public ActionResult Crear(int temaId)
        {
            ViewBag.Tema = service.getTemaCrear(temaId);
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            Validar(pregunta);
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = service.getTemaCrear(pregunta.Id);
                return View(pregunta);
            }
            service.AddPregunta(pregunta);
            

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {            
            var pregunta = service.GetPregunta(id);
            ViewBag.Tema = service.getTemaCrear(pregunta.TemaId);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = service.getTemaCrear(pregunta.TemaId);
                return View(pregunta);
            }
            service.Editar(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            service.Eliminar(id);

            return RedirectToAction("Index");
        }



        private void Validar(Pregunta pregunta)
        {
            if (pregunta.Alternativas.Count < 4)
                ModelState.AddModelError("Alternativas", "Las alternativas deben ser al menos 4");

            if (pregunta.Alternativas.Where(o => o.EsCorrecto).Count() == 0)
                ModelState.AddModelError("Alternativas", "Las alternativas deben tener al mensos una respusta correcta");
        }

    }
}