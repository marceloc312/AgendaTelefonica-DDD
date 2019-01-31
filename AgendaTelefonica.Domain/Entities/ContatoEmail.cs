using AgendaTelefonica.Domain.Contracts.Validation;
using AgendaTelefonica.Domain.Entities.Enums;
using AgendaTelefonica.Domain.Entities.Validations;
using AgendaTelefonica.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.Domain.Entities
{
	public class ContatoEmail : ISelfValidation
	{
		public ContatoEmail()
		{
		}

		public ContatoEmail(int id, int contatoId, string descricao, EnumClassificacao enumClassificacao)
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
		public virtual Contato Contato { get; set; }

		public virtual Validation.ValidationResult ValidationResult { get; protected set; }
		public virtual bool IsValid()
		{
			var fiscal = new EmailIsValidValidation();
			ValidationResult = fiscal.Valid(this);
			return ValidationResult.IsValid;
		}
	}
}
