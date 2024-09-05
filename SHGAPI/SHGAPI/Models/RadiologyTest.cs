using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class RadiologyTest
{
    public int Id { get; set; }

    public string TestName { get; set; } = null!;

    public string? TestResult { get; set; }

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
