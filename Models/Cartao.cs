using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PJGPlantasMVC.Models
{
    public class Cartao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cartao()
        {
            Compra = new HashSet<Compra>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeTitular { get; set; }

        [Required]
        [StringLength(5)]
        public string Validade { get; set; }

        [Required]
        [StringLength(3)]
        public string CVV { get; set; }

        [Required]
        [StringLength(19)]
        public string Numero { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
    }
}