using AgendaTelefonica.Domain.Contracts.Validation;
using AgendaTelefonica.Domain.Entities.Validations;
using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Domain.Entities
{
	public class Contato : ISelfValidation
	{
		public Contato()
		{
			Email = new List<ContatoEmail>();
			Telefone = new List<ContatoTelefone>();
		}

		public Contato(int id, string nome, string empresa, string endereco)
		{
			Id = id;
			Nome = nome;
			Email = new List<ContatoEmail>();
			Telefone = new List<ContatoTelefone>();
			Empresa = empresa;
			Endereco = endereco;
		}

		public virtual int Id { get; set; }
		[StringLength(60)]
		public virtual string Nome { get; set; }
		public virtual IList<ContatoEmail> Email { get; set; }
		public virtual IList<ContatoTelefone> Telefone { get; set; }
		[StringLength(50)]
		public virtual string Empresa { get; set; }
		[StringLength(150)]
		public virtual string Endereco { get; set; }

		public virtual Validation.ValidationResult ValidationResult { get; protected set; }
		public virtual bool IsValid()
		{
			var fiscal = new ContatoIsValidValidation();
			ValidationResult = fiscal.Valid(this);
			return ValidationResult.IsValid;
		}
		public virtual void AddEmail(ContatoEmail email)
		{
			email.Contato = this;
			Email.Add(email);
		}

		public virtual void AddTelefone(ContatoTelefone telefone)
		{
			telefone.Contato = this;
			Telefone.Add(telefone);
		}
	}
}
