using System;
using System.Collections.Generic;
using System.Linq;
namespace AgendaTelefonica.MVC.ViewsModels.Comum
{
	public class MenuVM
	{
		public MenuVM()
		{
			Ativo = new List<string>();
		}

		public string Descricao { get; set; }

		public string Icone { get; set; }

		public string Url { get; set; }

		public List<MenuVM> SubItens { get; set; }

		public List<string> Ativo { get; set; }

		public List<MenuVM> ObterMenu()
		{
			List<MenuVM> listaMenu = new List<MenuVM>();

			#region Modulo Admin
			MenuVM Admin = new MenuVM() { Descricao = "Admin", Icone = "fa fa-lock", SubItens = new List<MenuVM>(), Ativo = new List<string>() { } };

			if (Admin.SubItens.Count > 0)
				listaMenu.Add(Admin);
			#endregion

			#region Cadastros
			MenuVM cadastros = new MenuVM() { Descricao = "Cadastros", Icone = "fa fa-circle", SubItens = new List<MenuVM>(), Ativo = new List<string>() { "Contato" } };
			cadastros.SubItens.Add(new MenuVM() { Descricao = "Contato", Icone = "fa fa-circle-o", Url = "~/Contato", Ativo = new List<string>() { "Contato" } });

			if (cadastros.SubItens.Count > 0)
				listaMenu.Add(cadastros);
			#endregion

			return listaMenu;
		}

	}


}