using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePeliculas.CLases
{

  public  class PeliculaMax
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Año { get; set; }
        public Nullable<int> Genero { get; set; }
        [Display(Name = "Fecha de alta")]
        public Nullable<System.DateTime> FechaAlta { get; set; }

        public GeneroMax GeneroEnt { get; set; }
    }

}
