using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicePeliculas.CLases;
using WCFServicePeliculas.EF;

namespace WCFServicePeliculas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        public List<PeliculaMax> ListaPeliculas()
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                List<Pelicula> ls = db.Pelicula.Include("Genero1").ToList();
                List<PeliculaMax> lista = ls.Select(x => new PeliculaMax()
                {
                    Año = x.Año,
                    FechaAlta = x.FechaAlta,
                    Genero = x.Genero,
                    GeneroEnt = new GeneroMax()
                    {
                        Descripcion = x.Genero1.Descripcion,
                        IdGenero = x.Genero1.IdGenero
                    },
                    IdPelicula = x.IdPelicula,
                    Nombre = x.Nombre

                }).ToList();

                return lista;
            }
        }

        public PeliculaMax Obtener(int id)
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                Pelicula p = db.Pelicula.Include("Genero1").Where(x => x.IdPelicula == id).FirstOrDefault();
                if (p == null)
                {
                    return new PeliculaMax();
                }
                else
                {
                    PeliculaMax pe = new PeliculaMax();
                   
                    pe.Año = p.Año;
                    pe.FechaAlta = p.FechaAlta;
                    pe.Genero = p.Genero;
                    pe.IdPelicula = p.IdPelicula;
                    pe.Nombre = p.Nombre;
                    pe.GeneroEnt = new GeneroMax()
                    {
                        Descripcion = p.Genero1.Descripcion,
                        IdGenero = p.Genero1.IdGenero
                    };

                    return pe;
                }
            }
        }

        public void Agregar(Pelicula p)
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                p.FechaAlta = DateTime.Now;
                db.Entry(p).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();            
            }
        }

        public void Editar(Pelicula p)
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                Pelicula pe = db.Pelicula.Find(p.IdPelicula);
                pe.Genero = p.Genero;
                pe.Año = p.Año;
                pe.Nombre = p.Nombre;
                db.Entry(pe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(Pelicula p)
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                Pelicula pe = db.Pelicula.Find(p.IdPelicula);
                db.Entry(pe).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<GeneroMax>ListaGenero()
        {
            using (EntitiesPeliculas db = new EntitiesPeliculas())
            {
                List<Genero> ls = db.Genero.ToList();
                List<GeneroMax> lista = ls.Select(x => new GeneroMax()
                {
                    Descripcion = x.Descripcion,
                     IdGenero = x.IdGenero

                }).ToList();

                return lista;
            }
        }
    }
}
