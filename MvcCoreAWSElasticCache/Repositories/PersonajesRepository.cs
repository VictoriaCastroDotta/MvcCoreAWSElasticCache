using MvcCoreAWSElasticCache.Data;
using MvcCoreAWSElasticCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSElasticCache.Repositories
{
    public class PersonajesRepository
    {
        PersonajesContext Context;
        public PersonajesRepository(PersonajesContext context)
        {
            this.Context = context;
        }

        public List<Personaje> GetPersonajes()
        {
            return this.Context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.Context.Personajes.SingleOrDefault(x => x.IdPersonaje == id);
        }

        private int GetMaxId()
        {
            return this.Context.Personajes.Max(x => x.IdPersonaje) + 1;
        }

        public void InsertPersonaje(String nombre, String imagen)
        {
            Personaje per = new Personaje();
            per.IdPersonaje = this.GetMaxId();
            per.Nombre = nombre;
            per.Imagen = imagen;
            this.Context.Personajes.Add(per);
            this.Context.SaveChanges();
        }
    }
}
