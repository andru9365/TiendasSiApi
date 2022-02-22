using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasSiApi.Entities
{
    public class TiendasSiProducto
    {
        public int id { get; set; }
        [Required]
        public string nombreProducto { get; set; }
        [Required]
        public string detalleProducto { get; set; }
        public int idTipoProducto { get; set; }
        public bool estadoProducto { get; set; }
    }
}
