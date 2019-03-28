using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Entities;

using SistemaTelefonico.ViewModels;
using BusinessLogic;

namespace SistemaTelefonico.Controllers
{
    public class MunicipioController : Controller
    {
        private MunicipioBL municipioBL = new MunicipioBL();
        private DepartamentoBL departamentoBL = new DepartamentoBL();

        // GET: Municipio
        public ActionResult Index()
        {
            
            List<MunicipioViewModel> lst1 = new List<MunicipioViewModel>();
            IEnumerable<Municipio> lst2 = new List<Municipio>();
            lst2 = null;
            foreach (Municipio muni in lst2)
            {
                MunicipioViewModel municipio = new MunicipioViewModel();
                municipio.Codigo = muni.Codigo;
                municipio.Nombre = muni.Nombre;
                municipio.CodigoDepartamento = muni.CodigoDepartamento;
                municipio.Indicativo = muni.Indicativo;
                lst1.Add(municipio);
            }
            return View(lst1);
        }

        

        // GET: Municipio/Create
        public ActionResult Create()
        {
            MunicipioViewModel municipioViewModel = new MunicipioViewModel();
            municipioViewModel.ListaDepartamentos = new SelectList(departamentoBL.ObtenerListaDepartamentos(), "Codigo", "Nombre");
            return View(municipioViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MunicipioViewModel viewModel)
        {
            Entities.Municipio municipio = new Entities.Municipio();
            if (ModelState.IsValid)
            {

                municipio.Codigo = viewModel.Codigo;
                municipio.Nombre = viewModel.Nombre;
                municipio.CodigoDepartamento = viewModel.CodigoDepartamento;
                municipio.Indicativo = viewModel.Indicativo;
                bool existeMunicipio = municipioBL.CrearMunicipio(municipio);
                if (!existeMunicipio)
                {
                    
                    return RedirectToAction("YaExisteMunicipio");
                }
                
                return RedirectToAction("Index");
            }
           viewModel.ListaDepartamentos = new SelectList(viewModel.ListaDepartamentos, "Codigo", "Nombre");
            return View(viewModel);
        }

        public ActionResult YaExisteMunicipio()
        {
            return View();
        }


       
        [HttpGet]
        public ActionResult Buscar(int codigo)
        {
            Municipio municipio = new Municipio();
            municipio = municipioBL.BuscarMunicipioPorIndicativo(codigo);
            MunicipioViewModel municipioViewModel = new MunicipioViewModel();
            municipioViewModel.Codigo = municipio.Codigo;
            municipioViewModel.Nombre = municipio.Nombre;
            int codigoDepartamento = int.Parse(municipio.CodigoDepartamento);
            
            
            municipioViewModel.NombreDepartamento = ObtenerDepartamentoPorCodigo(codigoDepartamento);

            return View(municipioViewModel);
        }



        public string ObtenerDepartamentoPorCodigo(int idDepartment)
        {
            Departamento departamento = departamentoBL.BuscarDepartamentoPorCodigo(idDepartment);
            string nombreDepartamento = departamento.Nombre;
            return nombreDepartamento;
        }


    }
}
