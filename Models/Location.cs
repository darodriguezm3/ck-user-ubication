using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


public class Town
{
    [Column("town_id")]  // Esto mapea la propiedad TownId a la columna town_id en la base de datos
    public int TownId { get; set; }
    
    [Column("name")]  // Mapea DepartmentId a la columna department_id
    public string Name { get; set; }

    [Column("department_id")]  // Mapea DepartmentId a la columna department_id
    public int DepartmentId { get; set; }

    public Department Department { get; set; }
}

// Suggested code may be subject to a license. Learn more: ~LicenseLog:813787587.
public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }

    public Country Country { get; set; }
}

// Suggested code may be subject to a license. Learn more: ~LicenseLog:504023904.
public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; }
}