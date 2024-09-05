using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Growth
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public double? Weight { get; set; }

    public double? Height { get; set; }

    public double? Muac { get; set; }

    public int PatientId { get; set; }

    public int? ChildImmunizationId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ChildImmunization? ChildImmunization { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
