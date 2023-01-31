using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Compra
    {
        public Compra()
        {
            ItemCompra = new HashSet<ItemCompra>();
        }
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public int UsuarioId { get; set; }
        public int? BoletoId { get; set; }
        public int? PixId { get; set; }
        public int? CartaoId { get; set; }

        public virtual Boleto Boleto { get; set; }
        public virtual Cartao Cartao { get; set; }
        public virtual Pix Pix { get; set; }
        public virtual Usuario Usuario { get; set; }
        [JsonIgnore]
        public virtual ICollection<ItemCompra> ItemCompra { get; set; }
    }
}