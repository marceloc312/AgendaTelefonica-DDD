using AgendaTelefonica.Domain.Entities.Specifications.EmailSpecs;
using AgendaTelefonica.Domain.Validation;

namespace AgendaTelefonica.Domain.Entities.Validations
{
	public class EmailIsValidValidation : Validation<ContatoEmail>
	{
		public EmailIsValidValidation()
		{
			base.AddRule(new ValidationRule<ContatoEmail>(new EmailDevePossuirClassificacaoSpec(), ValidationMessages.ClassificacaoEmailObrigatoria));
			base.AddRule(new ValidationRule<ContatoEmail>(new EmailEnderecoDeveSerPreenchidoSpec(), ValidationMessages.EnderecoEmailDeveSerPreenchido));
			base.AddRule(new ValidationRule<ContatoEmail>(new EmailEnderecoDeveSerValidoSpec(), ValidationMessages.EnderecoEmailDeveSerValido));
		}
	}
}
