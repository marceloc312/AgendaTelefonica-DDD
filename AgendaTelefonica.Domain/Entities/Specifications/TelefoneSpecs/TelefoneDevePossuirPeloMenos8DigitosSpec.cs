using AgendaTelefonica.Domain.Contracts.Specification;
using System.Text.RegularExpressions;

namespace AgendaTelefonica.Domain.Entities.Specifications.TelefoneSpecs
{
	public class TelefoneDevePossuirPeloMenos8DigitosSpec : ISpecification<ContatoTelefone>
	{
		public bool IsSatisfiedBy(ContatoTelefone entity)
		{
			if (string.IsNullOrEmpty(entity.Numero))
				return false;

			string valor = new Regex(@"[^\d]").Replace(entity.Numero, "");
			return valor?.Length >= 8;
		}
	}
}
