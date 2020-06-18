using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
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
        private SimuladorContext context;

        public PreguntaController()
        {
            context = new SimuladorContext();
        }

        [HttpGet]
        public ActionResult Index(int temaId)
        {
            var tema = context.Temas
                .Include(o => o.Preguntas.Select(x => x.Alternativas))
                .Where(x => x.Id == temaId)
                .FirstOrDefault();

            return View(tema);
        }

        [HttpGet]
        public ActionResult Crear(int temaId)
        {
            ViewBag.Tema = context.Temas.Find(temaId);
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            Validar(pregunta);
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
                return View(pregunta);
            }

            context.Preguntas.Add(pregunta);
            context.SaveChanges();

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {            
            var pregunta = context.Preguntas.Find(id);
            ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = context.Temas.Find(pregunta.TemaId);
                return View(pregunta);
            }
            context.Entry(pregunta).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var pregunta = context.Preguntas.Find(id);
            context.Preguntas.Remove(pregunta);
            context.SaveChanges();

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