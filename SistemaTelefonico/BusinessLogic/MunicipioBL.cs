using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess;

namespace BusinessLogic
{
    public class MunicipioBL
    {
        public IEnumerable<Municipio> ObtenerListaMunicipios()
        {
            MunicipioDAO municipioDao = new MunicipioDAO();
            IEnumerable<Municipio> listaMunicipios = new List<Municipio>();
            listaMunicipios = municipioDao.QueryListarMunicipios();
            return listaMunicipios;
        }

        public bool CrearMunicipio(Municipio municipio)
        {
            StringBuilder sb = new StringBuilder();
            string codigo = municipio.Codigo.ToString();
            string codigoDepartamento = municipio.CodigoDepartamento.ToString();
            sb.Append(codigoDepartamento);
            sb.Append(codigo);

            municipio.Indicativo =sb.ToString();
            Municipio municip = new Municipio();
            municip = BuscarMunicipioPorCodigo(int.Parse(codigo), int.Parse(codigoDepartamento));

            if (!string.IsNullOrEmpty(municip.Codigo))
            {
                int codigoMunicipio1 = int.Parse(municipio.Codigo);
                int codigoDepartament1 = int.Parse(municipio.CodigoDepartamento);
                int codigoMunicipio2 = int.Parse(municip.Codigo);
                int codigoDepartament2 = int.Parse(municip.CodigoDepartamento);
                if (int.Parse(municip.Codigo) == codigoMunicipio1 && int.Parse(municip.CodigoDepartamento) == codigoDepartament1)
                {
                    return false;
                }
            }
            
            MunicipioDAO municipioDao = new MunicipioDAO();
            municipioDao.QueryCrearMunicipio(municipio);

            return true;
        }

        public Municipio BuscarMunicipioPorCodigo(int codigo, int codigoDepartment)
        {
            MunicipioDAO municipioDao = new MunicipioDAO();
            Municipio municipio = new Municipio();
            municipio = municipioDao.QueryBuscarMunicipioPorCodigo(codigo, codigoDepartment);

            return municipio;
        }

        public Municipio BuscarMunicipioPorIndicativo(int codigo)
        {
            MunicipioDAO municipioDao = new MunicipioDAO();
            Municipio municipio = new Municipio();
            municipio = municipioDao.QueryBuscarMunicipioPorIndicativo(codigo);

            return municipio;
        }
    }
}
