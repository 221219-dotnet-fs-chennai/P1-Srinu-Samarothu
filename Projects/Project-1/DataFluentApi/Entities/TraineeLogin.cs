using System;
using System.Collections.Generic;

namespace DataFluentApi.Entities;

public partial class TraineeLogin
{
    public string? Email { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public int? Tdstatus { get; set; }

    public int? Cdstatus { get; set; }

    public int? Edustatus { get; set; }

    public int? Edstatus { get; set; }

    public int? Sdstatus { get; set; }

    public virtual TraineeTrainerDetail? TraineeTrainerDetail { get; set; }
}
