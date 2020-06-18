using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Service
{
    public interface ITemaService {
        List<Tema> GetTemaAsqueryable(string criterio);
        List<Categoria> GetCategoria();
        void AddCategoria(Tema tema);
        void AddTemaCategoria(TemaCategoria temaCategoria);
        Tema GetTemasWhere(int id);
        void Editar(Tema tema);
        void Eliminar(int id);
    }
    public class TemaService : ITemaService
    {
        public SimuladorContext context = new SimuladorContext();
        public List<Tema> GetTemaAsqueryable(string criterio) {
            var temas = context.Temas.Include(a => a.Categorias.Select(o => o.Categoria)).AsQueryable();

            if (!string.IsNullOrEmpty(criterio))
                temas = temas.Where(o => o.Nombre.Contains(criterio));

            return temas.ToList(); 
        }
        public List<Categoria> GetCategoria()
        {
            return context.Categorias.ToList(); 
        }
        public void AddCategoria(Tema tema) {
            context.Temas.Add(tema);
            context.SaveChanges();
        }
        public void AddTemaCategoria(TemaCategoria temaCategoria) {
            context.TemaCategorias.Add(temaCategoria);
            context.SaveChanges();
        }
        public Tema GetTemasWhere(int id) {
            return context.Temas.Where(x => x.Id == id).First();
        }
        public void Editar(Tema tema) {
            context.Entry(tema).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Eliminar(int id) {
            Tema tema = context.Temas.Where(x => x.Id == id).First();
            context.Temas.Remove(tema);
            context.SaveChanges();

        }
    }
}