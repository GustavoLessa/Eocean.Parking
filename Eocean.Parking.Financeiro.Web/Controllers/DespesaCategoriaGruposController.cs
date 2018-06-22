using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eocean.Parking.Financeiro.Dominio.Entidades;
using Eocean.Parking.Financeiro.Dominio.Repositorio;
//using Eocean.Parking.Financeiro.Dominio.Validacoes;
using FluentValidation.Results;

namespace Eocean.Parking.Financeiro.Web.Controllers
{
    public class DespesaCategoriaGruposController : Controller
    {
        private DespesaCategoriaGrupoRepositorio _repositorio;
        
        // GET: DespesaCategoriaGrupos
        public ActionResult Index()
        {
            _repositorio = new DespesaCategoriaGrupoRepositorio();
            var grupos = _repositorio.DespesaCategoriaGrupos;
            return View(grupos);
        }

        // GET: DespesaCategoriaGrupos/Edit/5
        public ActionResult Alterar(int? idDespesaCategoriaGrupo)
        {
            _repositorio = new DespesaCategoriaGrupoRepositorio();

            DespesaCategoriaGrupo categoriaGrupo = _repositorio.DespesaCategoriaGrupos.FirstOrDefault(p => p.IdDespesaCategoriaGrupo == idDespesaCategoriaGrupo);
            if (categoriaGrupo == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGrupo);
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar([Bind(Include = "IdDespesaCategoriaGrupo,Nome,Descricao")] DespesaCategoriaGrupo despesaCategoriaGrupo)
        {
            //DespesaCategoriaGrupoValidacao grupoValidador = new DespesaCategoriaGrupoValidacao();
            //ValidationResult resultado = grupoValidador.Validate(despesaCategoriaGrupo);

            //despesaCategoriaGrupo.DtAlteracao = DateTime.Now;
            despesaCategoriaGrupo.IdUsuario = 1; //Todo trocar por usuário logado

            if (ModelState.IsValid)
            {
                _repositorio = new DespesaCategoriaGrupoRepositorio();
                _repositorio.Salvar(despesaCategoriaGrupo);

                TempData["mensagem"] = $"{despesaCategoriaGrupo.Nome} foi salvo com sucesso";

                return RedirectToAction("Index");
            }

            return View(despesaCategoriaGrupo);
        }
        

        public ViewResult Incluir()
        {
            return View("Alterar", new DespesaCategoriaGrupo());
        }

        [HttpPost]
        public JsonResult Excluir(int idDespesaCategoriaGrupo)
        {
            string mensagem = string.Empty;

            _repositorio = new DespesaCategoriaGrupoRepositorio();

            DespesaCategoriaGrupo grupo = _repositorio.Excluir(idDespesaCategoriaGrupo);

            if (grupo != null)
            {
                mensagem = $"{grupo.Nome} foi excluido com sucesso";
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}