using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class RefreshLog
{
    public string? ViewName { get; set; }

    public TimeSpan? Duration { get; set; }

    public DateTime? LoggedOn { get; set; }
}
