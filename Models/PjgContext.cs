using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class PjgContext : DbContext
    {

        public virtual DbSet<Boleto> Boleto { get; set; }
        public virtual DbSet<Cartao> Cartao { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<ItemCompra> ItemCompra { get; set; }
        public virtual DbSet<Pix> Pix { get; set; }
        public virtual DbSet<Planta> Planta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}