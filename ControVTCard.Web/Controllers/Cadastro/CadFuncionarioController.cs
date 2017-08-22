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
        public ActionResult Index()
        {
            return View(FuncionarioModel.RecuperarLista());
        }
    }
}