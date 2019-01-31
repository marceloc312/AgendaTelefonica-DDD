using AgendaTelefonica.Domain.Contracts.Specification;
using System;

namespace AgendaTelefonica.Domain.Entities.Specifications.TelefoneSpecs
{
	public class TelefoneDDDDeveSerPreenchidoSpec : ISpecification<ContatoTelefone>
	{
		public bool IsSatisfiedBy(ContatoTelefone entity)
		{
			return !string.IsNullOrEmpty(entity.DDD) && !String.IsNullOrWhiteSpace(entity.DDD);
		}
	}
}
