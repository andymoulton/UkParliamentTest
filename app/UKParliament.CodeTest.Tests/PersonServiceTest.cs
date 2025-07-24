using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using Xunit;

namespace UKParliament.CodeTest.Tests
{
    public class PersonServiceTest
    {
        private DbContextOptions<PersonManagerContext> GetOptions()
        {
            return new DbContextOptionsBuilder<PersonManagerContext>()
                .UseInMemoryDatabase(databaseName: "PersonServiceTestDb")
                .Options;
        }

        private PersonManagerContext SeedContext()
        {
            var options = GetOptions();
            var context = new PersonManagerContext(options);

            context.Departments.Add(new Department { Id = 1, Name = "Sales" });
            context.Departments.Add(new Department { Id = 2, Name = "HR" });

            context.People.Add(new Person
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@example.com",
                DateOfBirth = new DateOnly(1990, 1, 1),
                DepartmentId = 1
            });

            context.SaveChanges();
            return context;
        }

        [Fact]
        public void GetById_ReturnsPerson_WhenExists()
        {
            using var context = SeedContext();
            var service = new PersonService(context);

            var person = service.getById(1);

            Assert.NotNull(person);
            Assert.Equal("Alice", person.FirstName);
            Assert.Equal(1, person.DepartmentId);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenNotExists()
        {
            using var context = SeedContext();
            var service = new PersonService(context);

            var person = service.getById(999);

            Assert.Null(person);
        }

        [Fact]
        public void GetAll_ReturnsAllPeople()
        {
            using var context = SeedContext();
            var service = new PersonService(context);

            var people = service.getAll();

            Assert.Single(people);
            Assert.Equal("Alice", people[0].FirstName);
        }

        [Fact]
        public void Save_AddsNewPerson()
        {
            using var context = SeedContext();
            var service = new PersonService(context);

            var newPerson = new Person
            {
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob@example.com",
                DateOfBirth = new DateOnly(1985, 5, 5),
                DepartmentId = 2
            };

            service.Save(newPerson);

            var people = service.getAll();
            Assert.Equal(2, people.Count);
            Assert.Contains(people, p => p.FirstName == "Bob");
        }

        [Fact]
        public void Delete_RemovesPerson()
        {
            using var context = SeedContext();
            var service = new PersonService(context);

            var person = service.getById(1);
            service.Delete(person);

            var people = service.getAll();
            Assert.Empty(people);
        }
    }
}
