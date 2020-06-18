using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class ExamenController : Controller
    {
        

        SimuladorContext db;
        public ExamenController()
        {            
            db = new SimuladorContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            Usuario logged = GetLoggedUser();
            var examenes = db.Examenes
                .Where(o => o.UsuarioId == logged.Id)
                .Include(o => o.Tema)
                .Include(o => o.Preguntas)
                .ToList();
            return View(examenes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = db.Temas.ToList();
            return View(new Examen());
        }

        [HttpPost]
        public ActionResult Crear(Examen examen, int nroPreguntas)
        {
            if (ModelState.IsValid)
            {
                examen.EstaActivo = true;
                GuardarExamen(examen);
                List<Pregunta> preguntas = GenerarPreguntas(examen.TemaId, nroPreguntas);
                
                GuardarPreguntas(examen, preguntas);
                return RedirectToAction("Index");
            }

            ViewBag.Temas = db.Temas.ToList();
            return View(examen);
        }

        private void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;

                db.ExamenPreguntas.Add(examenPreguta);

                db.SaveChanges();
            }
        }

        private void GuardarExamen(Examen examen)
        {
            examen.UsuarioId = GetLoggedUser().Id;
            examen.FechaCreacion = DateTime.Now;
            db.Examenes.Add(examen);
            db.SaveChanges();
        }

        private Usuario GetLoggedUser()
        {
          return (Usuario)Session["Usuario"];
        }



        private List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = db.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas
                .OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();
        }
    }
}
