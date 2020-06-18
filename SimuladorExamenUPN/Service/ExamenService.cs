using Microsoft.Ajax.Utilities;
using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Service
{
    public class ExamenService: IExamenService
    {
        SimuladorContext db = new SimuladorContext();

        public List<Examen> GetExamenes(Usuario logged) {
            List<Examen> examenes = db.Examenes
           .Where(o => o.UsuarioId == logged.Id)
           .Include(o => o.Tema)
           .Include(o => o.Preguntas)
           .ToList();
            return examenes;
        }
        public List<Tema> GetTemas() {
            return db.Temas.ToList();
        }
        public void AddExamenPregunta(ExamenPregunta examenPregunta) {
            db.ExamenPreguntas.Add(examenPregunta);
            db.SaveChanges();
        }
        public void AddExamen(Examen examen) {
            db.Examenes.Add(examen);
            db.SaveChanges();
        }
        public void SaveChanges() {
            db.SaveChanges();
        }
        public List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas) {
            var basePreguntas = db.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas
                .OrderBy(x => Guid.NewGuid())
                .Take(nroPreguntas).ToList();

        }


    }
    public interface IExamenService {
        List<Examen> GetExamenes(Usuario logged);
        List<Tema> GetTemas();
        void AddExamenPregunta(ExamenPregunta examenPregunta);
         void AddExamen(Examen examen);
        void SaveChanges();
        List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas);
    }
}