using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Municipio municipio = new Municipio();
            //municipio.Codigo = "001";
            //municipio.Nombre = "Itagui";
            //municipio.CodigoDepartamento = "04";
            
            MunicipioBL municipioBl = new MunicipioBL();
            Console.WriteLine(municipioBl.ObtenerListaMunicipios());
            //municipioBl.CrearMunicipio(municipio);
            Console.ReadLine();
        }
    }
}
