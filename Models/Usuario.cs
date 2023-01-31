using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Cartao = new HashSet<Cartao>();
            Comentario = new HashSet<Comentario>();
            Compra = new HashSet<Compra>();
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cartao> Cartao { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [JsonIgnore]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}