using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Sede
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SedeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite nombre (Minimo 3 caracteres)")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite ciudad (Minimo 3 caracteres)")]
        public string Ciudad { get; set; }

        public virtual ICollection<Activo> Activos { get; set; }
    }
}