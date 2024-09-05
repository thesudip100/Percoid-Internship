using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class ServiceEngagementMv
{
    public string? District { get; set; }

    public string? Palika { get; set; }

    public string? Ward { get; set; }

    public string? Name { get; set; }

    public int? Id { get; set; }

    public string? Service { get; set; }

    public string? Gender { get; set; }

    public int? OpdFlg { get; set; }

    public int? MhFlg { get; set; }

    public int? ImmunFlg { get; set; }

    public int? TelehealthFlg { get; set; }

    public int? Growth { get; set; }

    public int? Refered { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }
}
