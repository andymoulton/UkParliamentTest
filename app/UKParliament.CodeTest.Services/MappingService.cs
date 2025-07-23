using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.ViewModels;

namespace UKParliament.CodeTest.Services
{
    public class MappingService : IMappingService
    {

        public MappingService() { }

        public PersonViewModel MapToViewModel(Person person)
        {
            if (person == null) return null;

            return new PersonViewModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                DepartmentId = person.DepartmentId
            };

        }

        public Person MapToEntity(PersonViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new Person
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                DepartmentId = viewModel.DepartmentId 
            };
        }
    }
}
