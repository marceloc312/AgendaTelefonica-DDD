using AgendaTelefonica.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.MVC.ViewModel
{
	public class ContatoEmailViewModel
	{
		public ContatoEmailViewModel()
		{
		}

		public ContatoEmailViewModel(int id, int contatoId, string descricao, EnumClassificacao enumClassificacao)
		{
			Id = id;
			ContatoId = contatoId;
			Endereco = descricao;
			Classificacao = (int)enumClassificacao;
		}

		public virtual int Id { get; set; }
		public virtual int ContatoId { get; set; }
		[StringLength(100)]
		public virtual string Endereco { get; set; }
		public virtual int Classificacao { get; set; }
		public bool Excluir{get;set;}
	}
}
