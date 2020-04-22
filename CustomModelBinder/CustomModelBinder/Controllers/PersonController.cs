using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomModelBinder.Controllers
{
    public class PersonController: Controller
    {
        private static List<PersonViewModel> people = new List<PersonViewModel>();

        public static PersonViewModel Get(Guid id)
        {
            foreach(var person in people)
            {
                if(person.Id == id)
                {
                    return person;
                }
            }

            PersonViewModel personViewModel = new PersonViewModel
            {
                Id = id,
                FirstName = "Bob",
                LastName = "Smith",
                Age = 35
            };
            people.Add(personViewModel);

            return personViewModel;
        }
    }
}
