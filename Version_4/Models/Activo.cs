using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Version_4.Models
{
    public class Activo
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivoID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Num_Serie { get; set; }

        [Required]
        public DateTime? Fecha_Compra { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Cobertura_Seguro { get; set; }

        [Required]
        public int Valor_Compra { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Garantia { get; set; }

        [Required]
        public DateTime? Fecha_Puesto_Servicio { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Vida_Util { get; set; }

        [Required]
        public int Valor_Residual { get; set; }

        public int? CategoriaID { get; set; }
        public int? SedeID { get; set; }
        public int? AmbienteID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual Ambiente Ambiente { get; set; }

        public virtual ICollection<Asignacion> Asignaciones { get; set; }
    }
}