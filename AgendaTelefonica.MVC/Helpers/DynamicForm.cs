using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AgendaTelefonica.MVC.Helpers
{
	public static class DynamicForm
	{
		public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string containerElement, string counterElement, string collectionProperty, Type nestedType, bool isContainsSelec2 = false, bool isContainsInputMask = false, bool isContainsMinimal = false, bool isContainsMaskMoney = false, string complemento = null)
		{
			var ticks = DateTime.UtcNow.Ticks;
			var nestedObject = Activator.CreateInstance(nestedType);

			if (!String.IsNullOrEmpty(complemento) && nestedType.GetProperties().Any(a => a.Name == "IdAmbiente"))
				nestedType.GetProperty("IdAmbiente").SetValue(nestedObject, Convert.ToInt32(complemento));

			var partial = HttpUtility.JavaScriptStringEncode(EditorExtensions.EditorFor(htmlHelper, x => nestedObject).ToHtmlString());
			partial = partial.Replace("nestedObject_", collectionProperty + "_" + ticks.ToString() + "_");
			partial = partial.Replace("nestedObject.", collectionProperty + "[" + ticks + "]" + ".");

			string funcSelect2 = string.Empty;
			if (isContainsSelec2)
				funcSelect2 = "$('.select2').each(function (index, value) {var placeh = $(this).attr('placeholder'); $(this).select2({placeholder: placeh,allowClear: true, language: 'pt-BR'});});";

			string funcInputMask = string.Empty;
			if (isContainsInputMask)
				funcInputMask = "$('.aplicarMascara:visible').each(function(){var placehoolderMascara = $(this).attr('PlaceholderMascara');var mascara = $(this).attr('Mascara');	if (placehoolderMascara == null || placehoolderMascara == undefined){placehoolderMascara = '';}	$(this).inputmask(mascara, { 'placeholder': placehoolderMascara });	});";

			string funcMaskMoney = string.Empty;
			if (isContainsMaskMoney)
				funcMaskMoney = "$('.maskMoney_').maskMoney({ prefix: '', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });";

			string funcMinimal = string.Empty;
			if (isContainsMinimal)
				funcMinimal = "$('.minimal:visible').each(function(){$(this).iCheck({ checkboxClass: 'icheckbox_minimal-blue',radioClass: 'iradio_minimal-blue'})});";

			//funcMinimal = "$('input[type=\"checkbox\"].minimal, input[type=\"radio\"].minimal').iCheck({checkboxClass: 'icheckbox_minimal-blue',radioClass: 'iradio_minimal-blue'});";

			var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}'); {4} {5} {6} {7} return false;", containerElement, counterElement, ticks, partial, funcSelect2, funcInputMask, funcMinimal, funcMaskMoney);
			TagBuilder tb = new TagBuilder("a");
			tb.Attributes.Add("href", "#");
			tb.Attributes.Add("onclick", js);
			tb.InnerHtml = linkText;
			var tag = tb.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(tag);
		}

		public static IHtmlString LinkToRemoveNestedForm(this HtmlHelper htmlHelper, string linkText, string container, string deleteElement)
		{
			var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);

			TagBuilder tb = new TagBuilder("a");
			tb.Attributes.Add("href", "#");
			tb.Attributes.Add("onclick", js);
			tb.Attributes.Add("title", "Remover");
			tb.AddCssClass("fa fa-trash-o");
			var tag = tb.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(tag);
		}

	}
}
