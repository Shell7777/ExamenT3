using SimuladorExamenUPN.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: HomeExamen
        SimuladorContext db;
        public HomeController()
        {
            db = new SimuladorContext();
        }
        public ActionResult Index()
        {
            var examenes = db.Examenes
                .Include(o => o.Tema.Categorias.Select(s =>s.Categoria))
                .Include(o =>o.Usuario)
                .Where(o => o.EstaActivo == true)
                .ToList();
            return View(examenes);
        }

        public ActionResult Confirmar(int ExamenId)
        {
            var examen = db.Examenes
                .Where(o => o.Id == ExamenId)
                .Include(o =>o.Tema)
                .Include(u => u.Usuario)
                .FirstOrDefault();
            return View(examen);
        }

        public ActionResult DarExamen(int ExamenId)
        {
            
            var examen = db.Examenes.Where(o => o.Id == ExamenId)
                .Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas))
                .FirstOrDefault();

            return View(examen);
        }
        
    }
}