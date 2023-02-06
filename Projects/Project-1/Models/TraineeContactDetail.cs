using System;
using System.Collections.Generic;

namespace Models;

public partial class TraineeContactDetail
{
    public long MobileNumber { get; set; }

    public string? AddressLane { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public int? Tid { get; set; }

    public string? MailId { get; set; }

}
