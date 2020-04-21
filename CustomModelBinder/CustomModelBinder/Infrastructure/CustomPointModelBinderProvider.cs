using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomModelBinder.Infrastructure
{
    public class CustomPointModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder binder = new CustomPointBinder(new SimpleTypeModelBinder(typeof(Point), loggerFactory));
            return context.Metadata.ModelType == typeof(Point) ? binder : null;
        }
    }
}