using Microsoft.AspNetCore.Identity;

public class Town
{
    public int TownId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}

// Suggested code may be subject to a license. Learn more: ~LicenseLog:813787587.
public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
}

// Suggested code may be subject to a license. Learn more: ~LicenseLog:504023904.
public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; }
}