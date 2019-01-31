using AgendaTelefonica.Domain.Contracts.Validation;
using AgendaTelefonica.Domain.Entities.Enums;
using AgendaTelefonica.Domain.Entities.Validations;
using AgendaTelefonica.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.Domain.Entities
{
	public class ContatoTelefone : ISelfValidation
	{
		public ContatoTelefone()
		{
		}

		public ContatoTelefone(int id, int contatoId, string dDI, string dDD, string numero, EnumClassificacao enumClassificacao)
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

		public virtual Validation.ValidationResult ValidationResult { get; protected set; }
		public virtual Contato Contato { get; set; }

		public virtual bool IsValid()
		{
			var fiscal = new TelefoneIsValidValidation();
			ValidationResult = fiscal.Valid(this);
			return ValidationResult.IsValid;
		}

	}
}
