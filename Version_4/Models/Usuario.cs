using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Usuario
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite tipo de identidad")]
        public string TipoIdent { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite numero de identidad")]
        public string NumIdent { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Digite numero de telefono")]
        public string Telefono { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FullName()
        {
            return this.Nombre + " " + this.Apellido;
        }

        public int? TipoUserID { get; set; }

        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}