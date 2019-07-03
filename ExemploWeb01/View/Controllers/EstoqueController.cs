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

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, int quantidade, decimal valor)
        {
            Estoque estoque = new Estoque();
            estoque.Nome = nome;
            estoque.Quantidade = quantidade;
            estoque.Valor = valor;

            int id = repositorio.Inserir(estoque);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Estoque estoque = repositorio.ObterPeloId(id);
            ViewBag.Estoque = estoque;
            return View();
        }

        public ActionResult Update(int id,string nome, int quantidade, decimal valor)
        {
            Estoque estoque = new Estoque();
            estoque.Id = id;
            estoque.Nome = nome;
            estoque.Quantidade = quantidade;
            estoque.Valor = valor;
            repositorio.Atualizar(estoque);
            return RedirectToAction("Index");
        }
    }
}