using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")] 
        public string Codigo{ get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Déscripción")]
        public string Descripcion { get; set; }
        public Electronica Marca { get; set; }
        public Electronica Categoria { get; set; }
    
        [DisplayName("Imagen Url")]
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

        //private decimal Precio;
        //[DisplayName("Precio_")]
        //public decimal precio
        //{
        //    get { return Precio; }
        //    set { Precio = value;}
        //}
        //[DisplayName("Precio")]
        //public string precioFormateado
        //{
        //    get { return Precio.ToString("C", CultureInfo.CreateSpecificCulture("es-AR")); }
        //}

    }

}
