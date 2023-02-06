using System;
using System.Collections.Generic;

namespace Models;

public partial class Education
{
    public string? UgCollege { get; set; }

    public int UgPercentage { get; set; }

    public int UgPassoutYear { get; set; }

    public string? PgCollege { get; set; }

    public int? PgPercentage { get; set; }

    public int? PgPassoutYear { get; set; }

    public int Tid { get; set; }

}
