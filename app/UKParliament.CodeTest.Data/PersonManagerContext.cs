using Microsoft.EntityFrameworkCore;

namespace UKParliament.CodeTest.Data;

public class PersonManagerContext : DbContext
{
    public PersonManagerContext(DbContextOptions<PersonManagerContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var random = new Random();
        int daysInFiftyYears = 50 * 365;
        DateOnly today = DateOnly.FromDateTime(DateTime.Today.AddYears(-50));

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Sales" },
            new Department { Id = 2, Name = "Marketing" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "HR" });

        string[] FirstNames = new string[] { "Andy", "Duncan", "Sarah", "Peter", "Claire", "Katia", "Ronnie", "Laura", "Inam", "Syed", "Deniz", "Apostolos", "Tim" };
        string[] LastNames = new string[] { "Walker", "White", "Edwards", "Hughes", "Wood", "Turner", "Bennett", "Moore", "Young", "Jackson", "Phillips", "Patel", "Cooper" };

        for (int i =1; i <= 100; i++)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = i, FirstName = FirstNames[random.Next(FirstNames.Length)], LastName = LastNames[random.Next(LastNames.Length)], DepartmentId = random.Next(1,4), DateOfBirth = today.AddDays(random.Next(daysInFiftyYears)) }
            );
        }

        //modelBuilder.Entity<Person>().HasData(
        //    new Person { Id = 1, FirstName = "Andy", LastName = "One", DepartmentId = 1, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 2, FirstName = "Duncan", LastName = "Two", DepartmentId = 2, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 3, FirstName = "Sarah", LastName = "Three", DepartmentId = 3, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 4, FirstName = "Peter", LastName = "Four", DepartmentId = 4, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 5, FirstName = "Claire", LastName = "Five", DepartmentId = 1, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 6, FirstName = "Katia", LastName = "Six", DepartmentId = 2, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 7, FirstName = "Ronnie", LastName = "Seven", DepartmentId = 3, DateOfBirth = new DateOnly(1995, 12, 3) },
        //    new Person { Id = 8, FirstName = "Laura", LastName = "Either", DepartmentId = 4, DateOfBirth = new DateOnly(1995, 12, 3) }
        //);

    }

    public DbSet<Person> People { get; set; }

    public DbSet<Department> Departments { get; set; }

    //public DbSet<Address> Addresses { get; set; }

}