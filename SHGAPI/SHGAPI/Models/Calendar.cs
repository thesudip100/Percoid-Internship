using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Calendar
{
    public DateOnly? Gregorian { get; set; }

    public string? BikramSambat { get; set; }

    public string? BikramSambatNe { get; set; }

    public int? YrNe { get; set; }

    public int? MonthNe { get; set; }

    public string? MonthNeText { get; set; }

    public int? DayNe { get; set; }

    public string? StartEndFlgNe { get; set; }
}
