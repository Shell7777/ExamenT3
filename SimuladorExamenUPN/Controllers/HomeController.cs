using SimuladorExamenUPN.DB;
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
    public class HomeController : Controller
    {
        // GET: HomeExamen
        
        IHome service;
        public HomeController(IHome service )
         {
            this.service = service;

        }
        public HomeController()
        {
            
            service = new HomeService();
        }
        public ActionResult Index()
        {
            var examenes = service.GetExamenes();
            return View(examenes);
        }

        public ActionResult Confirmar(int ExamenId)
        {
            var examen = service.confirmar(ExamenId);
            return View(examen);
        }

        public ActionResult DarExamen(int ExamenId)
        {

            var examen = service.DarExamen(ExamenId);

            return View(examen);
        }
        
    }
}