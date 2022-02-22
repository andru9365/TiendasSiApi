using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasSiApi.Entities
{
    public class TiendasSiTipoProducto
    {
        public int id { get; set; }
        [Required]
        public string nombreTipoProducto { get; set; }
        public bool estadoTipoProducto { get; set; }
    }
}
