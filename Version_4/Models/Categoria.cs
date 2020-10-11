using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Categoria
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite nombre (Minimo 3 caracteres)")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public virtual ICollection<Activo> Activos { get; set; }
    }
}