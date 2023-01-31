using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class ItemCompra
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int PlantaId { get; set; }
        public int Quantidade { get; set; }
        public DateTime Dth { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Planta Planta { get; set; }
    }
}