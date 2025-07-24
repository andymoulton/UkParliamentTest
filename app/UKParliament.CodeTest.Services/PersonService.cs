using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data;

namespace UKParliament.CodeTest.Services;

public class PersonService : IPersonService
{

    //private readonly PersonManagerContext _context;
    private readonly DbContext _context;

    public PersonService(DbContext context)
    {
        _context = context;
    }

    protected DbSet<Person> People => (_context as PersonManagerContext)?.People
                                         ?? _context.Set<Person>();

    public Person getById(int id)
    {
        var person = People.Find(id);
        return person; // Returns null if not found
    }

    public List<Person> getAll()
    {
        var people = People
        .Select(person => new Person
        {
           FirstName = person.FirstName,
           LastName = person.LastName,
           DateOfBirth = person.DateOfBirth,
           Id = person.Id,
           Email = person.Email,
           DepartmentId = person.DepartmentId,
           DepartmentName = GetDepartmentName(person.DepartmentId)
        })
        .ToList();
        return people;
    }

    public void Save(Person person)
    {
        if (person.Id == 0)
        {
            People.Add(person);
        }
        else
        {
            People.Update(person);
        }
        _context.SaveChanges();
    }

    public void Delete(Person person)
    {
        People.Remove(person);
        _context.SaveChanges();
    }

    public string? GetDepartmentName(int departmentId)
    {
        var department = _context.Set<Department>().Find(departmentId);
        return department?.Name;
    }


    // Implement methods to interact with the PersonManagerContext
    // For example, methods to get a person by ID, get all persons, etc.
}