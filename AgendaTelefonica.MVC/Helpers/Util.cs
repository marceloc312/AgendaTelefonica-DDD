using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.MVC.Helpers
{
	public class AlertaFeedback
	{
		public static AlertaFeedback CriaAlerta(string mensagem, EnumTipoAlertaFeedback tipoAlertaFeedback, string CodigoExcecao = "")
		{
			AlertaFeedback Alerta = new AlertaFeedback()
			{
				Mensagem = mensagem,
				TipoAlertaFeedback = tipoAlertaFeedback,
				CodigoExcecao = CodigoExcecao,
			};
			return Alerta;
		}
		public string CodigoExcecao { get; set; }

		public string Mensagem { get; set; }

		public string Titulo { get; private set; }


		private EnumTipoAlertaFeedback _TipoAlertaFeedback;

		public EnumTipoAlertaFeedback TipoAlertaFeedback
		{
			get { return _TipoAlertaFeedback; }
			set
			{
				_TipoAlertaFeedback = value;

				if (_TipoAlertaFeedback == EnumTipoAlertaFeedback.Sucesso)
					Titulo = "Sucesso !";
				else if (_TipoAlertaFeedback == EnumTipoAlertaFeedback.Erro || _TipoAlertaFeedback == EnumTipoAlertaFeedback.Atencao)
					Titulo = "Atenção !";

			}
		}



	}
	public enum EnumTipoAlertaFeedback
	{
		Sucesso = 1,
		Erro = 2,
		Atencao = 3
	}
}
