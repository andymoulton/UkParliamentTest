using System.Net.Sockets;

namespace UKParliament.CodeTest.Data;

public interface IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; } // Added just to make it available in TS client
    public int PersonId { get; set; }

}

public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; } // Added just to make it available in TS client
    public int PersonId {get; set; } 

}