using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace CustomModelBinder.Infrastructure
{
    public class CustomPointBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;

        public CustomPointBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var coordValues = bindingContext.ValueProvider.GetValue("Coordinates");
            if (coordValues == ValueProviderResult.None)
            {
                return fallbackBinder.BindModelAsync(bindingContext);
            }
            bindingContext.Result = ModelBindingResult.Success(Point.Parse(coordValues.FirstValue));
            return Task.CompletedTask;
        }
    }
}