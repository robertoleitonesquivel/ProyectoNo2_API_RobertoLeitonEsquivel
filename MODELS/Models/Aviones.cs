using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MODELS.Models
{
    public class Aviones
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        public int Serie { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 50 caracteres.")]
        public string Dimensiones { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        public int Distancia { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        public int IdModelo { get; set;}

        [Required(ErrorMessage = "El campo es requerido.")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 50 caracteres.")]
        public string NombreTecnico { get; set; }
    }
}