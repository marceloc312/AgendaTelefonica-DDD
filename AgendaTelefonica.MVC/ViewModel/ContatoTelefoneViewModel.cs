using AgendaTelefonica.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.MVC.ViewModel
{
	public class ContatoTelefoneViewModel 
	{
		public ContatoTelefoneViewModel()
		{
		}

		public ContatoTelefoneViewModel(int id, int contatoId, string dDI, string dDD, string numero, EnumClassificacao enumClassificacao)
		{
			Id = id;
			ContatoId = contatoId;
			DDI = dDI;
			DDD = dDD;
			Numero = numero;
			Classificacao = (int)enumClassificacao;
		}

		public virtual int Id { get; set; }
		public virtual int ContatoId { get; set; }
		[StringLength(4)]
		public virtual string DDI { get; set; }
		[StringLength(4)]
		public virtual string DDD { get; set; }
		[StringLength(9)]
		public virtual string Numero { get; set; }
		public virtual int Classificacao { get; set; }
		public bool Excluir { get; set; }

	}
}
