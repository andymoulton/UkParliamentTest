namespace UKParliament.CodeTest.Data;

public class IDepartment
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Department : IDepartment
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
