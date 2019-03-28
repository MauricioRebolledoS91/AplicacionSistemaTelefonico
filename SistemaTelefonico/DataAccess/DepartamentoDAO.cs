using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DepartamentoDAO
    {
        public IEnumerable<Departamento> QueryListarDepartamentos()
        {
            List<tbl_Departamento> listaDepartamentos = new List<tbl_Departamento>();
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                listaDepartamentos = bd.tbl_Departamento.ToList();
            }
            List<Departamento> lista = new List<Departamento>();
            foreach (tbl_Departamento departamento in listaDepartamentos)
            {
                Departamento departament = new Departamento();
                departament.Codigo = departamento.Codigo.ToString();
                departament.Nombre = departamento.Nombre;
                
                if (departamento.Codigo.ToString().Length < 2)
                    departament.Codigo = "0" + departamento.Codigo.ToString();
                else
                    departament.Codigo = departamento.Codigo.ToString();
                lista.Add(departament);
            }
            return lista;
        }

        public void QueryCrearDepartamento(Departamento departamento)
        {
            tbl_Departamento TblDepartamento = new tbl_Departamento();
            TblDepartamento.Codigo = int.Parse(departamento.Codigo);
            TblDepartamento.Nombre = departamento.Nombre;


            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                bd.tbl_Departamento.Add(TblDepartamento);
                bd.SaveChanges();
            }
        }

        public Departamento QueryBuscarDepartamentoPorCodigo(int codigo)
        {
            Departamento department = new Departamento();
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                tbl_Departamento departamento = bd.tbl_Departamento.Find(codigo);
                if (departamento != null)
                {
                    department.Codigo = departamento.Codigo.ToString();
                    department.Nombre = departamento.Nombre;
                    
                }
            }
            return department;
        }

        public void QueryEditarDepartamento(Departamento departamento)
        {
            string codigo = departamento.AntiguoCodigo;
            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                bd.sp_UpdateDepartamentos(int.Parse(departamento.Codigo),departamento.Nombre, int.Parse(departamento.AntiguoCodigo));
                
            }

            using (BDTelefoniaEntities bd = new BDTelefoniaEntities())
            {
                string indicativoCompleto;

                List<tbl_Municipio> lstMunicipios = bd.tbl_Municipio.ToList();
                foreach(tbl_Municipio tbl in lstMunicipios)
                {
                    
                    string digito = "0";
                    string indicativo;
                    if (tbl.Codigo.ToString().Length == 2)
                    {
                        indicativo = digito + tbl.Codigo.ToString();
                        indicativoCompleto = departamento.Codigo + indicativo;
                    }else if (tbl.Codigo.ToString().Length == 1)
                    {
                        indicativo = digito + "0" + tbl.Codigo.ToString();
                        indicativoCompleto = departamento.Codigo + indicativo;
                    }
                    else
                    {
                        indicativoCompleto = departamento.Codigo + tbl.Codigo.ToString();
                    }
                    if (tbl.CodigoDepartamento == int.Parse(departamento.Codigo))
                    {
                        tbl.Indicativo = int.Parse(indicativoCompleto);
                    }

                }
                bd.SaveChanges();
                //TblDepartamento.Codigo = int.Parse(departamento.Codigo);
                //TblDepartamento.Nombre = departamento.Nombre;
                //bd.SaveChanges();
            }
        }

        
    }
}
