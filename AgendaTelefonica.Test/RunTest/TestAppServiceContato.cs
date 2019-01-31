using AgendaTelefonica.ApplicationService.Contracts;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Entities.Enums;
using AgendaTelefonica.Domain.Validation;
using AgendaTelefonica.InversionOfControl;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTelefonica.Test.RunTest
{
	[TestClass]
	public class TestAppServiceContato
	{
		readonly Fixture _builder;
		readonly IAppServiceContato _appService;
		public TestAppServiceContato()
		{
			var kernel = new IoC().Kernel;
			_appService = kernel.Get<IAppServiceContato>();
			_builder = new Fixture();
		}

		[TestMethod]
		public void Create()
		{
			Contato contato = new Contato(0, "Teste 1", null, null);
			contato.AddTelefone(new ContatoTelefone(0, 0, "+55", "11", "89890976", EnumClassificacao.Outro));
			contato.AddEmail(new ContatoEmail(0, 0, "marcelo@teste.com", EnumClassificacao.Casa));
			ValidationResult result = _appService.SaveOrUpdate(contato);

			if (!result.IsValid)
				Assert.Fail(String.Join("-", result.Errors.Select(s => s.Message)));
			Assert.IsTrue(result.IsValid);
		}

		[TestMethod]
		public void ValidationCampos()
		{
			List<string> mensagens = new List<string>();

			Contato contato = new Contato(0, "Teste 1", null, null);
			contato.AddTelefone(new ContatoTelefone(0, 0, "+55", "11", "898909", EnumClassificacao.Outro));
			contato.AddTelefone(new ContatoTelefone(0, 0, "", "", "", EnumClassificacao.Outro));
			contato.AddEmail(new ContatoEmail(0, 0, "marcelo@teste.com", EnumClassificacao.Casa));

			contato.IsValid();

			mensagens.AddRange(contato.ValidationResult.Errors.Select(s => "Erro CONTATO: " + s.Message));

			foreach (var item in contato.Telefone)
			{
				item.IsValid();
				mensagens.AddRange(item.ValidationResult.Errors.Select(s => "Erro TELEFONE: " + s.Message));
			}
			foreach (var item in contato.Email)
			{
				item.IsValid();
				mensagens.AddRange(item.ValidationResult.Errors.Select(s => "Erro EMAIL: " + s.Message));
			}
			string strMensagem = String.Join("-", mensagens);

			if (!String.IsNullOrEmpty(strMensagem))
				Assert.Fail(strMensagem);

			Assert.IsTrue(String.IsNullOrEmpty(strMensagem));

		}

		[TestMethod]
		public void Update()
		{
			int id = _appService.All().FirstOrDefault().Id;
			var model = _appService.Get(id);
			model.Nome = $"Editado {DateTime.Now.Millisecond}";
			model.Empresa = "Empresa 13" + DateTime.Now.Millisecond;
			model.Endereco = "endereco 2";
			model.AddTelefone(new ContatoTelefone(0, 0, null, "11", "90908765", EnumClassificacao.Trabalho));
			model.AddTelefone(new ContatoTelefone(0, 0, null, "11", "00000000", EnumClassificacao.Trabalho));
			model.Telefone.RemoveAt(0);
			model.Email.FirstOrDefault().Classificacao = (int)EnumClassificacao.Trabalho;

			var result = _appService.SaveOrUpdate(model);

			if (!result.IsValid)
				Assert.Fail(String.Join("-", result.Errors.Select(s => s.Message)));
			Assert.IsTrue(result.IsValid);
		}


		[TestMethod]
		public void Delete()
		{
			int id = _appService.All().FirstOrDefault().Id;
			var model = _appService.Get(id);

			var result = _appService.Delete(model);

			if (!result.IsValid)
				Assert.Fail(String.Join("-", result.Errors.Select(s => s.Message)));
			Assert.IsTrue(result.IsValid);
		}

		[TestMethod]
		public void Listar()
		{
			var lista = _appService.All();

			Assert.IsTrue(lista.Any());
		}
	}
}
