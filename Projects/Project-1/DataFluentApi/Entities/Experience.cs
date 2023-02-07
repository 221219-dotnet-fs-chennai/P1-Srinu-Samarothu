using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class Experience
{
    public string? Company { get; set; } = null!;

    public string? Designation { get; set; } = null!;

    public int OverallExperience { get; set; }

    public int Tid { get; set; }

    public virtual TraineeTrainerDetail TidNavigation { get; set; } = null!;
}
