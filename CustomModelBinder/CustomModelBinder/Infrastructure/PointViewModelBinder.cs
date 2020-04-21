using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace CustomModelBinder.Infrastructure
{
    public class PointViewModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var coordValues = bindingContext.ValueProvider.GetValue("Coordinates");
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, coordValues);
            if (coordValues == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            bindingContext.Result = ModelBindingResult.Success(PointViewModel.Parse(coordValues.FirstValue));
            return Task.CompletedTask;
        }
    }
}