using CustomModelBinder.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomModelBinder.Models
{
    [ModelBinder(typeof(PersonViewModelBinder))]

    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
