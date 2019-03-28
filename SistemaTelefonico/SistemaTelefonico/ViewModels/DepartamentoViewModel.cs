using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTelefonico.ViewModels
{
    public class DepartamentoViewModel
    {
        [Required(ErrorMessage = "El codigo no puede estar en blanco")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Por favor ingrese un indicativo de 2 digitos ")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "por favor, insertar solo números")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de departamento no puede estar en blanco")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El nombre de los departamentos solo deben tener letras")]
        public string Nombre { get; set; }

        public string AntiguoCodigo { get; set; }

        

    }
}