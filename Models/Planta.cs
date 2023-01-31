using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Planta
    {
        public Planta()
        {
            Comentario = new HashSet<Comentario>();
            ItemCompra = new HashSet<ItemCompra>();
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [JsonIgnore]
        public virtual ICollection<ItemCompra> ItemCompra { get; set; }
    }
}