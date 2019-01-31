using AgendaTelefonica.ApplicationService.Contracts;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Entities.Enums;
using AgendaTelefonica.Domain.Validation;
using AgendaTelefonica.MVC.AutoMapper;
using AgendaTelefonica.MVC.Helpers;
using AgendaTelefonica.MVC.Helpers.UTIL;
using AgendaTelefonica.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AgendaTelefonica.MVC.Controllers
{
	public class ContatoController : Controller
	{
		readonly IAppServiceNotification _appServiceNotification;
		readonly IAppServiceContato _appServiceContato;

		public ContatoController(IAppServiceNotification appServiceNotification, IAppServiceContato appServiceContato)
		{
			_appServiceNotification = appServiceNotification;
			_appServiceContato = appServiceContato;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult Listar(DTParameters param)
		{
			string[] columnFilters = param.Columns.Select(x => x.Search.Value).ToArray();

			string criterio = null;
			if (!string.IsNullOrEmpty(columnFilters[0]))
				criterio = columnFilters[0].ToLower();

			IEnumerable<Contato> contatos = String.IsNullOrEmpty(criterio) ? _appServiceContato.All() :
				_appServiceContato.Find(w => w.Nome.Contains(criterio)
			   || w.Telefone.Any(wt => wt.Numero.Contains(criterio) || wt.Numero.Contains(criterio))
			   || w.Email.Any(we => we.Endereco.Contains(criterio)));

			List<object> dados = contatos.Select(s => FormatDataView(s)).ToList();

			DTResult<object> result = new DTResult<object>
			{
				draw = param.Draw,
				data = dados,
				recordsFiltered = param.TotalRegistros,
				recordsTotal = param.TotalRegistros
			};

			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Edit(int? id)
		{
			ObterBase();
			ContatoViewModel model = null;

			try
			{

				if (id == null)
					model = new ContatoViewModel();
				else
				{
					var contato = _appServiceContato.Get(id.GetValueOrDefault());
					model = MapperConfig.Mapper.Map<ContatoViewModel>(contato);
				}
			}
			catch (Exception ex)
			{
				ObterBase();
				int codigoNotificacao = _appServiceNotification.Notify(ex.Message);
				TempData["AlertaFeedback"] = AlertaFeedback.CriaAlerta($"Ocorreu ao salvar o contato. CÓDIGO DE ERRO: {codigoNotificacao}", EnumTipoAlertaFeedback.Erro);
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ContatoViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					model.Telefone.RemoveAll(w => w.Excluir);
					model.Email.RemoveAll(w => w.Excluir);
					Contato contato = MapperConfig.Mapper.Map<ContatoViewModel, Contato>(model);

					var validation = _appServiceContato.SaveOrUpdate(contato);
					if (GetFeedback(validation))
						return RedirectToAction("Index");
				}
			}
			catch (Exception ex)
			{
				ObterBase();
				int codigoNotificacao = _appServiceNotification.Notify(ex.Message);
				TempData["AlertaFeedback"] = AlertaFeedback.CriaAlerta($"Ocorreu ao salvar o contato. CÓDIGO DE ERRO: {codigoNotificacao}", EnumTipoAlertaFeedback.Erro);
			}
			return View(model);
		}

		private bool GetFeedback(ValidationResult validation)
		{
			string mensagem = "Contato salvo com sucesso!";
			EnumTipoAlertaFeedback feedback = EnumTipoAlertaFeedback.Sucesso;
			if (!validation.IsValid)
			{
				mensagem = String.Join("-", validation.Errors.Select(s => s.Message));
				feedback = EnumTipoAlertaFeedback.Atencao;
			}
			TempData["AlertaFeedback"] = AlertaFeedback.CriaAlerta(mensagem, feedback);

			return feedback == EnumTipoAlertaFeedback.Sucesso;
		}

		// GET: Aplicacao/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				var contato = _appServiceContato.Get(id);

				var validation = _appServiceContato.Delete(contato);
				GetFeedback(validation);
			}
			catch (Exception ex)
			{
				int codigoNotificacao = _appServiceNotification.Notify(ex.Message);
				TempData["AlertaFeedback"] = AlertaFeedback.CriaAlerta($"Ocorreu ao excluir o contato. CÓDIGO DE ERRO: {codigoNotificacao}", EnumTipoAlertaFeedback.Erro);
			}
			return RedirectToAction("Index");
		}

		void ObterBase()
		{
			ViewBag.Classificacao = new SelectList(new[]
			{
				new {value = (int)EnumClassificacao.Casa,text="Casa" },
				new {value = (int)EnumClassificacao.Outro,text="Outro" },
				new {value =(int) EnumClassificacao.Trabalho,text="Trabalho" },
			}, "value", "text");
		}
		object FormatDataView(Contato s)
		{
			return new
			{
				s.Id,
				s.Nome,
				Telefone = String.Join("/", s.Telefone.Select(st => $"{st.DDD} - {st.Numero} { (EnumClassificacao)st.Classificacao}")),
				Email = String.Join("/", s.Email.Select(se => $"{se.Endereco} { (EnumClassificacao)se.Classificacao}"))
			};
		}
	}
}
