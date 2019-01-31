using AgendaTelefonica.InversionOfControl.Modules;
using Ninject;

namespace AgendaTelefonica.InversionOfControl
{
	public class IoC
	{
		public IoC()
		{
			Kernel = CreateKernel();
		}

		public IKernel Kernel { get; }


		private IKernel CreateKernel()
		{
			return new StandardKernel(new RepostoryModule(),
				new AppServiceModule(),
				new ServiceModule()
				);
		}
	}
}