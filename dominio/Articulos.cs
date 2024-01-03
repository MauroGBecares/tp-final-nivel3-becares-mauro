using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Articulos
    {        
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Categoría")]
        public Categorias Categoria { get; set; }
        public Marcas Marca { get; set; }
        public string UrlImagen { get; set; }
        private decimal precio { get; set; }
        public decimal Precio
        {
            get { return precio;  }
            set { precio = Math.Round(value, 2); }
        }

    }
}
