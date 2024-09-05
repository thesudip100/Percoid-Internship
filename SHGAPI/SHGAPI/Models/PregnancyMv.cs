using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class PregnancyMv
{
    public string? District { get; set; }

    public string? Palika { get; set; }

    public string? Ward { get; set; }

    public string? Name { get; set; }

    public int? PregCountFlg { get; set; }

    public int? PregLess20Flg { get; set; }

    public int? PregMore20Flg { get; set; }

    public int? ConsultantionFlg { get; set; }

    public string? FilterRange { get; set; }
}
