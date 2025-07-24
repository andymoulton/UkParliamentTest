using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    public class ValidatePersonService : IValidatePersonService
    {

        readonly IPerson _person;

        public ValidatePersonService(IPerson person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }

        public List<string> ValidatePerson()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(_person.FirstName))
                errors.Add("First name is required.");

            if (string.IsNullOrWhiteSpace(_person.LastName))
                errors.Add("Last name is required.");

            //if (string.IsNullOrWhiteSpace(_person.Email) || !_person.Email.Contains("@"))
            //    errors.Add("A valid email is required.");

            if (_person.DateOfBirth == default)
                errors.Add("Date of birth is required.");

            if (_person.DepartmentId == 0)
                errors.Add("Department is required.");

            // Add more rules as needed

            return errors;
        }
    }
}
