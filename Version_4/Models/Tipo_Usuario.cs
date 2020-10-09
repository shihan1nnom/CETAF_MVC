using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Tipo_Usuario
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoUserID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        public bool Usuario { get; set; }

        [Required]
        public bool Categoria { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public bool TipoUser { get; set; }

        [Required]
        public bool Sedes { get; set; }

        [Required]
        public bool Ambientes { get; set; }

        [Required]
        public bool Asignar { get; set; }

        [Required]
        public bool Consulta { get; set; }

        [Required]
        public bool CopiaSeguridad { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}