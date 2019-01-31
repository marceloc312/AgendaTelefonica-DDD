using AgendaTelefonica.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Context.Mapping
{
	class ContatoMapping : ClassMap<Contato>
	{
		public ContatoMapping()
		{
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Nome);
			Map(x => x.Empresa);
			Map(x => x.Endereco);

			HasMany(x => x.Email)
			  .Inverse()
			  .Cascade.AllDeleteOrphan();

			HasMany(x => x.Telefone)
			  .Inverse()
			  .Cascade.AllDeleteOrphan();
		}
	}
}
