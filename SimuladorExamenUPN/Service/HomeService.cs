using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Service
{
    public class HomeService : IHome
    {
        SimuladorContext db = new SimuladorContext();
        public List<Examen> GetExamenes() {
            var examenes = db.Examenes
                  .Include(o => o.Tema.Categorias.Select(s => s.Categoria))
                  .Include(o => o.Usuario)
                  .Where(o => o.EstaActivo == true)
                  .ToList();
            return examenes;
        }
        public Examen confirmar(int ExamenId) {
            var examen = db.Examenes
                   .Where(o => o.Id == ExamenId)
                   .Include(o => o.Tema)
                   .Include(u => u.Usuario)
                   .FirstOrDefault();
            return examen;
        }
        public Examen DarExamen(int ExamenId) {
            var examen = db.Examenes.Where(o => o.Id == ExamenId)
                 .Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas))
                 .FirstOrDefault();

            return examen;
        }


    }
    public interface IHome{
        List<Examen> GetExamenes();
        Examen confirmar(int ExamenId);
        Examen DarExamen(int ExamenId);
    }
}