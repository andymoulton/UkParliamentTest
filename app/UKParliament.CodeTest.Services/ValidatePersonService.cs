using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services
{
    internal class ValidatePersonService : IValidatePersonService
    {

        public List<string> ValidatePerson(Person person)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(person.FirstName))
                errors.Add("First name is required.");

            if (string.IsNullOrWhiteSpace(person.LastName))
                errors.Add("Last name is required.");

            if (string.IsNullOrWhiteSpace(person.Email) || !person.Email.Contains("@"))
                errors.Add("A valid email is required.");

            if (person.DateOfBirth == default)
                errors.Add("Date of birth is required.");

            if (person.DepartmentId == 0)
                errors.Add("Department is required.");

            // Add more rules as needed

            return errors;
        }
    }
}
