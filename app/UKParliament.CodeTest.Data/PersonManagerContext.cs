using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Department>().HasData(
        //    new Department { Id = 1, Name = "Sales" },
        //    new Department { Id = 2, Name = "Marketing" },
        //    new Department { Id = 3, Name = "Finance" },
        //    new Department { Id = 4, Name = "HR" });

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "Andy", LastName = "One", DepartmentId = 1, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 2, FirstName = "Duncan", LastName = "Two", DepartmentId = 2, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 3, FirstName = "Sarah", LastName = "Three", DepartmentId = 3, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 4, FirstName = "Peter", LastName = "Four", DepartmentId = 4, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 5, FirstName = "Claire", LastName = "Five", DepartmentId = 1, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 6, FirstName = "Katia", LastName = "Six", DepartmentId = 2, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 7, FirstName = "Ronnie", LastName = "Seven", DepartmentId = 3, DateOfBirth = new DateOnly(1995, 12, 3) },
            new Person { Id = 8, FirstName = "Laura", LastName = "Either", DepartmentId = 4, DateOfBirth = new DateOnly(1995, 12, 3) }
        );

    }

    public DbSet<Person> People { get; set; }

    //public DbSet<Department> Departments { get; set; }

    //public DbSet<Address> Addresses { get; set; }

}