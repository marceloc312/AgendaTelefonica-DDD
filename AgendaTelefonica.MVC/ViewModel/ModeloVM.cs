namespace AgendaTelefonica.MVC.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	public partial class ModeloVM
	{
		public ModeloVM()
		{
		}

		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Descrição")]
		public string Descricao { get; set; }

		[Display(Name = "Ativo")]
		public bool Ativo { get; set; }
		[Display(Name = "Ordem")]
		public int Ordem { get; set; }
	}
}
