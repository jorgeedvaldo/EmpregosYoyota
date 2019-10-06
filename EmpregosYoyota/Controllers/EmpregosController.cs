using EmpregosYoyota.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpregosYoyota.Controllers
{
    public class EmpregosController : Controller
    {
        IEnumerable<VerEmprego> TodosEmpregos = new VerEmprego().TodosEmpregos();

        public ActionResult Index(String categoria = "Tudo", int p = 1)
        {
            ViewBag.NumeroItensNaPagina = 20;
            ViewBag.Categorias = TodosEmpregos.Select(x => x.Nome).Distinct().ToList();
            ViewBag.CategoriaActual = categoria;
            ViewBag.PaginaActual = p;
            ViewBag.ContarEmpregos = TodosEmpregos.Where(x => x.IdCategoria == 1).ToList().Count;
            var CategoriaEspecifica = TodosEmpregos.Where(x => x.Nome.ToLower() == categoria.ToLower()).ToList();
            return View(CategoriaEspecifica);
        }

        public ActionResult Item(int id)
        {   
            var EmpregoActual = TodosEmpregos.Where(x => x.IdEmprego == id).ToList();
            ViewBag.CategoriasDoEmprego = EmpregoActual.Select(x => x.Nome).Distinct().ToList();
            ViewBag.ContarEmpregos = TodosEmpregos.Where(x => x.IdCategoria == 1).ToList().Count;
            var emprego = EmpregoActual.Take(1).ToList()[0];
            return View(emprego);
        }

    }
}
