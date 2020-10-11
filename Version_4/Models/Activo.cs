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

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimo 3 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimo 3 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string Num_Serie { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.Date)]
        public string Fecha_Compra { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimo 3 caracteres maximo 200")]
        [DataType(DataType.Text)]
        public string Cobertura_Seguro { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.Currency)]
        public string Valor_Compra { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimo 3 caracteres maximo 200")]
        [DataType(DataType.Text)]
        public string Garantia { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.Date)]
        public string Fecha_Puesto_Servicio { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Minimo 3 caracteres maximo 200")]
        [DataType(DataType.Text)]
        public string Vida_Util { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [DataType(DataType.Currency)]
        public string Valor_Residual { get; set; }

        public int? CategoriaID { get; set; }
        //public int? SedeID { get; set; }
        //public int? AmbienteID { get; set; }

        public virtual Categoria Categoria { get; set; }
        //public virtual Sede Sede { get; set; }
        //public virtual Ambiente Ambiente { get; set; }

        public virtual ICollection<Asignacion> Asignaciones { get; set; }
    }
}