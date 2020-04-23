using CustomModelBinder.Converters;
using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CustomModelBinder.Binders
{
    public class PersonViewModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var base64Id = (string)bindingContext.HttpContext.GetRouteValue("id");

            if (GuidConverter.TryConvertBase64ToGuid(base64Id, out Guid id))
            {
                bindingContext.Result = ModelBindingResult.Success(new PersonViewModel
                {
                    Id = id,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Age = 23
                });
            }

            return Task.CompletedTask;
        }
    }
}
