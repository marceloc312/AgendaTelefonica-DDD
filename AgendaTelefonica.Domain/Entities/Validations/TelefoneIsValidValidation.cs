using AgendaTelefonica.Domain.Entities.Specifications.TelefoneSpecs;
using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Domain.Entities.Validations
{
public	class TelefoneIsValidValidation : Validation<ContatoTelefone>
	{
		public TelefoneIsValidValidation()
		{
			base.AddRule(new ValidationRule<ContatoTelefone>(new TelefoneClassificacaoDeveSerInformadaSpec(), ValidationMessages.ClassificacaoTelefoneObrigatoria));
			base.AddRule(new ValidationRule<ContatoTelefone>(new TelefoneDDDDeveSerPreenchidoSpec(), ValidationMessages.DDDTelefoneObrigatorio));
			base.AddRule(new ValidationRule<ContatoTelefone>(new TelefoneDevePossuirPeloMenos8DigitosSpec(), ValidationMessages.NumeroTelefoneDevePossuirPeloMenos8Digitos));
			base.AddRule(new ValidationRule<ContatoTelefone>(new TelefoneNumeroDeveSerPreenchidoSpec(), ValidationMessages.NumeroTelefoneDeveSerPreenchido));
		}
	}
}
