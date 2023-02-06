using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class Skill
{
    public string Skill1 { get; set; } = null!;

    public int Proficiency { get; set; }

    public int Tid { get; set; }

    public virtual TraineeTrainerDetail TidNavigation { get; set; } = null!;
}
