using System;
using System.Web.Mvc;

namespace AgendaTelefonica.MVC.ViewModel
{
	public class DecimalModelBinder : DefaultModelBinder
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

			return valueProviderResult == null ? base.BindModel(controllerContext, bindingContext) : !String.IsNullOrEmpty(valueProviderResult.AttemptedValue) ? Convert.ToDecimal(valueProviderResult.AttemptedValue) : 0;

		}
	}

}