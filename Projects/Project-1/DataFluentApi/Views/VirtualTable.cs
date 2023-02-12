using System;
using System.Collections.Generic;

namespace DataFluentApi.Views;

public partial class VirtualTable
{
    public int Tid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Mail { get; set; }

    public string? Gender { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public string? UgCollege { get; set; }

    public int? UgPercentage { get; set; }

    public int? UgPassoutYear { get; set; }

    public string? PgCollege { get; set; }

    public int? PgPercentage { get; set; }

    public int? PgPassoutYear { get; set; }

    public string? Company { get; set; }

    public string? Designation { get; set; }
}
