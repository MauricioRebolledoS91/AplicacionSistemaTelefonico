using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DepartamentoBL
    {
        public IEnumerable<Departamento> ObtenerListaDepartamentos()
        {
            DepartamentoDAO departamentoDao = new DepartamentoDAO();
            IEnumerable<Departamento> listaDepartamentos = new List<Departamento>();
            listaDepartamentos = departamentoDao.QueryListarDepartamentos();
            return listaDepartamentos;
        }
        public bool CrearDepartamento(Departamento departamento)
        {
            DepartamentoDAO departmentDAO = new DepartamentoDAO();
            departmentDAO.QueryCrearDepartamento(departamento);

            return true;
        }

        public Departamento BuscarDepartamentoPorCodigo(int codigo)
        {
            DepartamentoDAO departamentoDao = new DepartamentoDAO();
            Departamento departamento = new Departamento();
            departamento = departamentoDao.QueryBuscarDepartamentoPorCodigo(codigo);

            return departamento;
        }

        public void EditarDepartamento(Departamento departamento)
        {
            DepartamentoDAO departamentoDao = new DepartamentoDAO();
            departamentoDao.QueryEditarDepartamento(departamento);
        }
        
       
    }
}
