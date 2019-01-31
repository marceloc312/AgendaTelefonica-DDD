using AgendaTelefonica.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Context.Mapping
{
	class TelefoneMapping : ClassMap<ContatoTelefone>
	{
		public TelefoneMapping()
		{
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Classificacao);
			
			Map(x => x.DDD);
			Map(x => x.DDI);
			Map(x => x.Numero);

			References(x => x.Contato).Column("ContatoId");
		}
	}
}
