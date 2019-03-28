using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTelefonico.ViewModels
{
    public class MunicipioViewModel
    {
        [Required(ErrorMessage = "El codigo no puede estar en blanco")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Por favor ingrese un indicativo de 3 digitos ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "por favor, insertar solo números")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de municipio no puede estar en blanco")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El nombre de los municipios solo deben tener letras")]
        public string Nombre { get; set; }

        
        public string CodigoDepartamento { get; set; }

        public string NombreDepartamento { get; set; }

        public string Indicativo { get; set; }
        public SelectList ListaDepartamentos { get; set; }
    }
}