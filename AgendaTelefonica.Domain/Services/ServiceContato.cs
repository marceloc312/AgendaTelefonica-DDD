using AgendaTelefonica.Domain.Contracts.Repository;
using AgendaTelefonica.Domain.Contracts.Service;
using AgendaTelefonica.Domain.Entities;

namespace AgendaTelefonica.Domain.Services
{
	public class ServiceContato : Service<Contato>, IServiceContato
	{
		public ServiceContato(IRepositoryContato repository) : base(repository)
		{
		}
	}
}