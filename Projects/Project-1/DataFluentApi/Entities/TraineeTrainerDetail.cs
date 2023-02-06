using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TraineeTrainerDetail
{
    public int Tid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Dob { get; set; }

    public string? Mail { get; set; } = null!;

    public virtual Education? Education { get; set; }

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual TraineeLogin MailNavigation { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();

    public virtual TraineeContactDetail? TraineeContactDetail { get; set; }
}
