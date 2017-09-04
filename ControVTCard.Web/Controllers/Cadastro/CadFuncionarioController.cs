using ControVTCard.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControVTCard.Web.Controllers.Cadastro
{
    public class CadFuncionarioController : Controller
    {
        // GET: CadFuncionario
        private const int _quantMaxLinhasPorPagina = 1;

        public ActionResult Index()
        {
            return View(FuncionarioModel.RecuperarLista());
        }
        public ActionResult Cad()
        {
            ViewBag.ListaTamPag = new SelectList(new int[] { _quantMaxLinhasPorPagina, 2 }, _quantMaxLinhasPorPagina);
            return View();
        }

    }
}