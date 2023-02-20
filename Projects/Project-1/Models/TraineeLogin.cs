using System;
using System.Collections.Generic;

namespace Models;

public class TraineeLogin
{
    public string? Email { get; set; }

    public string? Password { get; set; }


    public override string ToString()
    {
        return $"\nLogin Details :\nEmail : {Email}";
    }

    // \nTdstatus : {Tdstatus}\nCdstatus : {Cdstatus}\nEdustatus : {Edustatus}\nEdstatus : {Edstatus}\nSdstatus : {Sdstatus}";
}
