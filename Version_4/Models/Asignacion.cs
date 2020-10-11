using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Asignacion
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AsignacionesID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite nombre (Minimo 3 caracteres)")]
        public string Nombre_Activo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite nombre (Minimo 3 caracteres)")]
        public string Nombre_Person_Respon { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Sede no valida")]
        public string Sede_Asinada { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ambiente no valido")]
        public string Ambiente_Asignado { get; set; }

        [Required]
        public DateTime? Fecha_inicio { get; set; }

        [Required]
        public DateTime? Fecha_Fin { get; set; }

        public int? ActivoID { get; set; }

        public virtual Activo Activo { get; set; }

    }
}