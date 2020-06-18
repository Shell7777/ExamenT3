using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.Service;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class ExamenController : Controller
    {
   
        public IExamenService service ;
        public ILogginService logginService;
        public ExamenController()
        {            
    
            service = new ExamenService();
        }
        public ExamenController(IExamenService service) {
            this.service = service;
        }
        public ExamenController(IExamenService service,ILogginService  logginService)
        {
            this.service = service;
            this.logginService = logginService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Usuario logged = GetLoggedUser();
            var examenes = service.GetExamenes(logged);
            return View(examenes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = service.GetTemas();
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

            ViewBag.Temas = service.GetTemas();
            return View(examen);
        }

        private void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;

                service.AddExamenPregunta(examenPreguta);

            }
        }

        private void GuardarExamen(Examen examen)
        {
            examen.UsuarioId = GetLoggedUser().Id;
            examen.FechaCreacion = DateTime.Now;
            service.AddExamen(examen);
        }

        private Usuario GetLoggedUser()
        {
          return (Usuario)Session["Usuario"];
        }



        private List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            return service.GenerarPreguntas(tema, nroPreguntas);
            /*var basePreguntas = db.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas
                .OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();*/
        }
    }
}
