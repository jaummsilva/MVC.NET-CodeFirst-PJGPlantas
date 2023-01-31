using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Boleto
    {
        public Boleto()
        {
            Compra = new HashSet<Compra>();
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}