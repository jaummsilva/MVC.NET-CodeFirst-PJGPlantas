using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public int PlantaId { get; set; }
        public DateTime Dth { get; set; }

        public virtual Planta Planta { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}