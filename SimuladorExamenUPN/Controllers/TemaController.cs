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
    public class TemaController : Controller
    {
        public SimuladorContext context;
        public TemaController()
        {
           context = new SimuladorContext();
        }
        [HttpGet]
        public ViewResult Index(string criterio)
        {
         
            var temas = context.Temas.Include(a=>a.Categorias.Select(o=>o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));

            ViewBag.Criterio = criterio;
            return View(temas.ToList());
        }

        [HttpGet]
        public ViewResult Crear()
        {
            ViewBag.Categorias = context.Categorias.ToList();
            ViewBag.Message = "Pantalla de crear";
            return View(new Tema());
        }

        [HttpPost]
        public ActionResult Crear(Tema tema,List<int> Ids)
        {

            ViewBag.Categorias = context.Categorias.ToList();           

            if (ModelState.IsValid == true)
            {
               
                context.Temas.Add(tema);
                context.SaveChanges();
               

                foreach (var categoriaid in Ids)
                {
                   var temaCategoria = new TemaCategoria() { CategoriaId = categoriaid, TemaId = tema.Id };
                    context.TemaCategorias.Add(temaCategoria);
                    context.SaveChanges();
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
            
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            
                      
            return View(tema);
        }

        [HttpPost]
        public ActionResult Editar(Tema tema)
        {      
            if (ModelState.IsValid == true)
            {
                context.Entry(tema).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tema);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
           
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            context.Temas.Remove(tema);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}