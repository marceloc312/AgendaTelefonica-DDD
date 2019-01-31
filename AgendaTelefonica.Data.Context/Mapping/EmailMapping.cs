using AgendaTelefonica.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Context.Mapping
{
	class EmailMapping : ClassMap<ContatoEmail>
	{
		public EmailMapping()
		{
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Endereco);
			Map(x => x.Classificacao);
			References(x => x.Contato).Column("ContatoId");
		}
	}
}
