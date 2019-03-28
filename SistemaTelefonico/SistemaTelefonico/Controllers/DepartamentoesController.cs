using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Entities;
using SistemaTelefonico.ViewModels;

namespace SistemaTelefonico.Controllers
{
    public class DepartamentoesController : Controller
    {
        private DepartamentoBL db = new DepartamentoBL();

        // GET: Departamentoes
        public ActionResult Index()
        {
            List<DepartamentoViewModel> lst1 = new List<DepartamentoViewModel>();
            IEnumerable<Departamento> lst2 = new List<Departamento>();
            lst2 = db.ObtenerListaDepartamentos();
            foreach (Departamento muni in lst2)
            {
                DepartamentoViewModel departamento = new DepartamentoViewModel();
                departamento.Codigo = muni.Codigo;
                departamento.Nombre = muni.Nombre;
                lst1.Add(departamento);
            }
            return View(lst1);
        }

       

        // GET: Departamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentoViewModel departamento)
        {
            Entities.Departamento department = new Entities.Departamento();
            if (ModelState.IsValid)
            {

                department.Codigo = departamento.Codigo;
                department.Nombre = departamento.Nombre;

                db.CrearDepartamento(department);

                
            }

            return RedirectToAction("Index");
        }

        // GET: Departamentoes/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.BuscarDepartamentoPorCodigo(id);
            DepartamentoViewModel deparViewModel = new DepartamentoViewModel();
            string codigoDepartamento = departamento.Codigo.ToString();
            if(codigoDepartamento.Length < 2)
            {
                deparViewModel.Codigo = "0" + codigoDepartamento;
                deparViewModel.Nombre = departamento.Nombre;
                deparViewModel.AntiguoCodigo = codigoDepartamento;
            }
            else
            {
                deparViewModel.Codigo = departamento.Codigo;
                deparViewModel.Nombre = departamento.Nombre;
                deparViewModel.AntiguoCodigo = codigoDepartamento;
            }
            
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(deparViewModel);
        }

        // POST: Departamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartamentoViewModel departamento)
        {
            Entities.Departamento department = new Entities.Departamento();
            if (ModelState.IsValid)
            {

                department.Codigo = departamento.Codigo;
                department.Nombre = departamento.Nombre;
                department.AntiguoCodigo = departamento.AntiguoCodigo;
                db.EditarDepartamento(department);


            }
            return RedirectToAction("Index");
        }

        //// GET: Departamentoes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Departamentos departamento = db.Departamentos.Find(id);
        //    if (departamento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(departamento);
        //}

        //// POST: Departamentoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Departamentos departamento = db.Departamentos.Find(id);
        //    db.Departamentos.Remove(departamento);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
