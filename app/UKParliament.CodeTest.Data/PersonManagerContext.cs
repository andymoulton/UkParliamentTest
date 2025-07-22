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

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "One", LastName = "One" },
            new Person { Id = 2, FirstName = "Two", LastName = "Two" },
            new Person { Id = 3, FirstName = "Three", LastName = "Three" },
            new Person { Id = 4, FirstName = "Four", LastName = "Four" },
            new Person { Id = 5, FirstName = "Five", LastName = "Five" });

    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Address> Addresses { get; set; }

}