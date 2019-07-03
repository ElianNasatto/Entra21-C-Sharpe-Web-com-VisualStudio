using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class EstoqueController : Controller
    {
        EstoqueRepositorio repositorio = new EstoqueRepositorio();

        public ActionResult Index()
        {
            List<Estoque> estoques = repositorio.ObterTodos("");

            ViewBag.Estoques = estoques;

            return View();
        }
    }
}