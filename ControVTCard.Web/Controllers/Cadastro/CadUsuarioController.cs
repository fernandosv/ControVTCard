using ControVTCard.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControVTCard.Web.Controllers
{
    public class CadUsuarioController : Controller
    {
        private const string _senhaPadrao = "{$127;$188}";

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.SenhaPadrao = _senhaPadrao;

            var lista = UsuarioModel.RecuperarLista();

            ViewBag.QuantMaxLinhasPorPagina = 5;
            ViewBag.PaginaAtual = 1;
            
            var difQuantPaginas = (lista.Count % ViewBag.QuantMaxLinhasPorPagina) > 0 ? 1 : 0;
            ViewBag.QuantPaginas = (lista.Count / ViewBag.QuantMaxLinhasPorPagina) + difQuantPaginas;

            return View(lista);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarUsuario(int id)
        {
            return Json(UsuarioModel.RecuperarPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirUsuario(int id)
        {
            return Json(UsuarioModel.ExcluirPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarUsuario(UsuarioModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    if (model.Senha == _senhaPadrao)
                    {
                        model.Senha = "";
                    }

                    var id = model.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

    }
}