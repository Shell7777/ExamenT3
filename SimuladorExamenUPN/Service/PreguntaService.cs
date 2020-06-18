using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Service
{
    public interface IPreguntaService {
        Tema getTema(int temaId);
        Tema getTemaCrear(int temaId);
        void AddPregunta(Pregunta pregunta);
        Pregunta GetPregunta(int id);
        void Eliminar(int id);
        void Editar(Pregunta pregunta);

    }
    public class PreguntaService : IPreguntaService
    {
        SimuladorContext context = new SimuladorContext();
        public Tema getTema(int temaId) {
            var tema = context.Temas
                .Include(o => o.Preguntas.Select(x => x.Alternativas))
                .Where(x => x.Id == temaId)
                .FirstOrDefault();
            return tema;
        }
        public Tema getTemaCrear(int temaId) {
            return context.Temas.Find(temaId);
        }
        public void AddPregunta(Pregunta pregunta) {
            context.Preguntas.Add(pregunta);
            context.SaveChanges();
        }
        public Pregunta GetPregunta(int id) {
            var pregunta = context.Preguntas.Find(id);
            return pregunta;
        }
        public void Editar(Pregunta pregunta)
        {
            context.Entry(pregunta).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Eliminar(int id) {
            var pregunta =
           context.Preguntas.Find(id);
            context.Preguntas.Remove(pregunta);
            context.SaveChanges();
        }

    }
}