using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Pix
    {
        public Pix()
        {
            Compra = new HashSet<Compra>();
        }
        [Key]
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Banco { get; set; }

        [JsonIgnore]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}