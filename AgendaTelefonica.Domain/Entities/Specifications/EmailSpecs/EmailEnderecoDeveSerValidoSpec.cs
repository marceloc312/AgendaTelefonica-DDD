using AgendaTelefonica.Domain.Contracts.Specification;
using System.Text.RegularExpressions;

namespace AgendaTelefonica.Domain.Entities.Specifications.EmailSpecs
{
	public class EmailEnderecoDeveSerValidoSpec : ISpecification<ContatoEmail>
	{
		public bool IsSatisfiedBy(ContatoEmail entity)
		{
			return new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$").IsMatch(entity.Endereco);
		}
	}
}
