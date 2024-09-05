using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class History
{
    public int Id { get; set; }

    public string MedicalHistory { get; set; } = null!;

    public string SurgicalHistory { get; set; } = null!;

    public string GyeObs { get; set; } = null!;

    public string DrugHistory { get; set; } = null!;

    public string FamilyHistory { get; set; } = null!;

    public string SocialHistory { get; set; } = null!;

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
