using AgendaTelefonica.Domain.Contracts.Specification;

namespace AgendaTelefonica.Domain.Entities.Specifications.TelefoneSpecs
{
	public	class TelefoneClassificacaoDeveSerInformadaSpec : ISpecification<ContatoTelefone>
	{
		public bool IsSatisfiedBy(ContatoTelefone entity)
		{
			return entity.Classificacao > 0;
		}
	}
}