using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTelefonico.ViewModels
{
    public class BuscarViewModel
    {
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdMunicipio { get; set; }
        public string Municipio { get; set; }
    }
}