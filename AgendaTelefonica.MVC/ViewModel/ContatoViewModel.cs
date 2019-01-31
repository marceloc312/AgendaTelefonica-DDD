using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.MVC.ViewModel
{
	public class ContatoViewModel
	{
		public ContatoViewModel()
		{
			Email = new List<ContatoEmailViewModel>();
			Telefone = new List<ContatoTelefoneViewModel>();
		}

		public ContatoViewModel(int id, string nome, string empresa, string endereco)
		{
			Id = id;
			Nome = nome;
			Email = new List<ContatoEmailViewModel>();
			Telefone = new List<ContatoTelefoneViewModel>();
			Empresa = empresa;
			Endereco = endereco;
		}

		public virtual int Id { get; set; }
		[StringLength(60)]
		public virtual string Nome { get; set; }
		public virtual List<ContatoEmailViewModel> Email { get; set; }
		public virtual List<ContatoTelefoneViewModel> Telefone { get; set; }
		[StringLength(50)]
		public virtual string Empresa { get; set; }
		[StringLength(150)]
		public virtual string Endereco { get; set; }
		
		public virtual void AddEmail(ContatoEmailViewModel email)
		{
			Email.Add(email);
		}

		public virtual void AddTelefone(ContatoTelefoneViewModel telefone)
		{
			Telefone.Add(telefone);
		}
	}
}
