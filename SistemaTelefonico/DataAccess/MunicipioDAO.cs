using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class MunicipioDAO
    {
        

        public IEnumerable<Municipio> QueryListarMunicipios()
        {
            List<tbl_Municipio> listaMunicipios = new List<tbl_Municipio>();
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                listaMunicipios = bd.tbl_Municipio.ToList();
            }
            List<Municipio> lista = new List<Municipio>();
            foreach(tbl_Municipio municipio in listaMunicipios)
            {
                Municipio municip = new Municipio();
                
                municip.Codigo = municipio.Codigo.ToString();
                municip.Nombre = municipio.Nombre;
                municip.CodigoDepartamento = municipio.CodigoDepartamento.ToString();
                if(municipio.Indicativo.ToString().Length < 5) 
                municip.Indicativo = "0" + municipio.Indicativo.ToString();
                else
                    municip.Indicativo = municipio.Indicativo.ToString();
                lista.Add(municip);
            }
            return lista;
        }


        public void QueryCrearMunicipio(Municipio municipio)
        {
            tbl_Municipio tblMunicipio = new tbl_Municipio();
            tblMunicipio.Codigo = int.Parse(municipio.Codigo);
            tblMunicipio.Nombre = municipio.Nombre;
            tblMunicipio.CodigoDepartamento = int.Parse(municipio.CodigoDepartamento);
            tblMunicipio.Indicativo = int.Parse(municipio.Indicativo);

            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                bd.tbl_Municipio.Add(tblMunicipio);
                bd.SaveChanges();
            }
        }


        public Municipio QueryBuscarMunicipioPorCodigo(int codigo, int codigoDepartamento)
        {
            Municipio municip = new Municipio();
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                

                tbl_Municipio municipio = bd.tbl_Municipio.FirstOrDefault(c => c.Codigo == codigo && c.CodigoDepartamento == codigoDepartamento);
                if(municipio != null) { 
                municip.Codigo = municipio.Codigo.ToString();
                municip.Nombre = municipio.Nombre;
                municip.CodigoDepartamento = municipio.CodigoDepartamento.ToString();
                municip.Indicativo = municipio.Indicativo.ToString();
                }
            }
            return municip;
        }

        public Municipio QueryBuscarMunicipioPorIndicativo(int indicativo)
        {
            Municipio muni = new Municipio();
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                var query = from mun in bd.tbl_Municipio
                            where mun.Indicativo == indicativo
                            select mun;

                foreach(tbl_Municipio municipio in query)
                {
                    muni.Codigo = municipio.Codigo.ToString();
                    muni.Nombre = municipio.Nombre;
                    muni.CodigoDepartamento = municipio.CodigoDepartamento.ToString();

                }
                
            }

            return muni; ;
        }
    }
}
