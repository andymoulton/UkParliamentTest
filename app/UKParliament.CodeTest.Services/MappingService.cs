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

        //readonly IPerson _person;
        //readonly IPersonViewModel _personViewModel;

        //public MappingService(IPerson person = null, IPersonViewModel personViewModel = null)
        //{
        //    _person = person; // ?? throw new ArgumentNullException(nameof(person));
        //    _personViewModel = personViewModel; // ?? throw new ArgumentNullException(nameof(personViewModel));
        //}

        public PersonViewModel MapToViewModel(Person _person)
        {
            if (_person == null) throw new ArgumentNullException(nameof(_person));

            return new PersonViewModel
            {
                FirstName = _person.FirstName,
                LastName = _person.LastName,
                DateOfBirth = _person.DateOfBirth,
                DepartmentId = _person.DepartmentId,
                DepartmentName = _person.DepartmentName
            };

        }

        public Person MapToEntity(PersonViewModel _personViewModel)
        {
            if (_personViewModel == null) throw new ArgumentNullException(nameof(_personViewModel));

            return new Person
            {
                FirstName = _personViewModel.FirstName,
                LastName = _personViewModel.LastName,
                DateOfBirth = _personViewModel.DateOfBirth,
                DepartmentId = _personViewModel.DepartmentId
            };
        }
    }
}
