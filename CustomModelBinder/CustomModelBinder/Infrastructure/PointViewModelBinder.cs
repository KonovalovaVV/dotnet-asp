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

            ValueProviderResult coordinateValues = bindingContext.ValueProvider.GetValue("Coordinates");
           
            if (coordinateValues == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(PointViewModel.Parse(coordinateValues.FirstValue));
           
            return Task.CompletedTask;
        }
    }
}