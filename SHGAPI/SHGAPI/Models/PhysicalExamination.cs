using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class PhysicalExamination
{
    public int Id { get; set; }

    public string GeneralCondition { get; set; } = null!;

    public string Chest { get; set; } = null!;

    public string Cvs { get; set; } = null!;

    public string Cns { get; set; } = null!;

    public string Perabominal { get; set; } = null!;

    public string LocalExamination { get; set; } = null!;

    public int PatientId { get; set; }

    public int EncounterId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
