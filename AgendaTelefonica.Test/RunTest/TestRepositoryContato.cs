using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Domain.Contracts.Repository;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Entities.Enums;
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
	public class TestRepositoryContato
	{

		readonly Fixture _builder;
		readonly IRepositoryContato _repository;
		readonly IUnitOfWork _unitOfWork;
		public TestRepositoryContato()
		{
			var kernel = new IoC().Kernel;
			_repository = kernel.Get<IRepositoryContato>();
			_unitOfWork = kernel.Get<IUnitOfWork>();
			_builder = new Fixture();
		}

		[TestMethod]
		public void Create()
		{
			_unitOfWork.BeginTransaction();

			Contato contato = new Contato(0, "Teste 1", null, null);
			contato.AddTelefone(new ContatoTelefone(0, 0, "+55", "11", "89890976", EnumClassificacao.Outro));
			contato.AddEmail(new ContatoEmail(0, 0, "marcelo@teste.com", EnumClassificacao.Casa));
			_repository.Add(contato);

			_unitOfWork.SaveChanges();
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
			_unitOfWork.BeginTransaction();
			int id = 9;
			var model = _repository.Get(id);
			model.Nome = $"Editado {DateTime.Now.Millisecond}";
			model.Empresa = "Empresa 13"+DateTime.Now.Millisecond;
			model.Endereco = "endereco 2";
			model.AddTelefone(new ContatoTelefone(0, 0, null, "11", "90908765", EnumClassificacao.Trabalho));
			model.AddTelefone(new ContatoTelefone(0, 0, null, "11", "00000000", EnumClassificacao.Trabalho));
			model.Telefone.RemoveAt(0);
			model.Email.FirstOrDefault().Classificacao = (int)EnumClassificacao.Trabalho;
			_repository.SaveOrUpdate(model);
			_unitOfWork.SaveChanges();

			_unitOfWork.BeginTransaction();

			var modelNew = _repository.Get(id);
			_unitOfWork.SaveChanges();

			Assert.AreEqual(model.Empresa, modelNew.Empresa);
		}


		[TestMethod]
		public void Delete()
		{
			_unitOfWork.BeginTransaction();
			int id = 9;
			var model = _repository.Get(id);

			_repository.Delete(model);
			_unitOfWork.SaveChanges();

			_unitOfWork.BeginTransaction();


			var modelNew = _repository.Get(id);
			_unitOfWork.SaveChanges();

			Assert.IsNull(modelNew);
		}

		[TestMethod]
		public void Listar()
		{
			_unitOfWork.BeginTransaction();

			var lista = _repository.All();
			_unitOfWork.SaveChanges();

			Assert.IsTrue(lista.Any());
		}
	}
}
