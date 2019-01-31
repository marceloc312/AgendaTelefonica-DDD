using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.MVC.ViewModel;
using AutoMapper;

namespace AgendaTelefonica.MVC.AutoMapper
{
	public static class MapperConfig
	{
		static IMapper _mapper;
		public static void RegisterMappings()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ContatoViewModel, Contato>();
				cfg.CreateMap<Contato, ContatoViewModel>();

				cfg.CreateMap<ContatoTelefoneViewModel, ContatoTelefone>();
				cfg.CreateMap<ContatoTelefone, ContatoTelefoneViewModel>();

				cfg.CreateMap<ContatoEmailViewModel, ContatoEmail>();
				cfg.CreateMap<ContatoEmail, ContatoEmailViewModel>();

			});
			_mapper = config.CreateMapper();
		}
		public static IMapper Mapper => _mapper;
	}
}