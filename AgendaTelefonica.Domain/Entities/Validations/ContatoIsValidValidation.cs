using AgendaTelefonica.Domain.Entities.Specifications.ContatoSpecs;
using AgendaTelefonica.Domain.Validation;

namespace AgendaTelefonica.Domain.Entities.Validations
{
	public	class ContatoIsValidValidation : Validation<Contato>
	{
		public ContatoIsValidValidation()
		{
			base.AddRule(new ValidationRule<Contato>(new ContatoNomeDeveSerPreenchidoSpec(), ValidationMessages.NomeContatoObrigatorio));
			base.AddRule(new ValidationRule<Contato>(new ContatoTelefoneDeveSerInformadoSpec(), ValidationMessages.TelefoneContatoObrigatorio));
		}
	}
}
