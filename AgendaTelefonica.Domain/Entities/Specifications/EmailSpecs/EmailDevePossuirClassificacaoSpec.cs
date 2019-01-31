using AgendaTelefonica.Domain.Contracts.Specification;

namespace AgendaTelefonica.Domain.Entities.Specifications.EmailSpecs
{
	public class EmailDevePossuirClassificacaoSpec : ISpecification<ContatoEmail>
	{
		public bool IsSatisfiedBy(ContatoEmail entity)
		{
			return entity.Classificacao > 0;
		}
	}
}
