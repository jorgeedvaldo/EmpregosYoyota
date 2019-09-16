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


        public ActionResult Index(String categoria = "Tudo")
        {
            ViewBag.Categorias = TodosEmpregos.Select(x => x.Nome).Distinct().ToList();
            var CategoriaEspecifica = TodosEmpregos.Where(x => x.Nome.ToLower() == categoria.ToLower()).ToList();
            return View(CategoriaEspecifica);
        }

        public ActionResult Item()
        {
            return View();
        }

    }
}
