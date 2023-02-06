using System;
using System.Collections.Generic;

namespace Models;

public partial class TraineeLogin
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Tdstatus { get; set; }

    public int? Cdstatus { get; set; }

    public int? Edustatus { get; set; }

    public int? Edstatus { get; set; }

    public int? Sdstatus { get; set; }

    public override string ToString()
    {
        return $"\nLogin Details :\nEmail : {Email}";
    }

    // \nTdstatus : {Tdstatus}\nCdstatus : {Cdstatus}\nEdustatus : {Edustatus}\nEdstatus : {Edstatus}\nSdstatus : {Sdstatus}";
}
