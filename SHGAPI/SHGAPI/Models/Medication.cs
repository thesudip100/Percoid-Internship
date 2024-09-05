using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Medication
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? MedicineName { get; set; }

    public string? Dosage { get; set; }

    public string? Times { get; set; }

    public string? BeforeAfter { get; set; }

    public string? Duration { get; set; }

    public string? SpecialNotes { get; set; }

    public int PatientId { get; set; }

    public int EncounterId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Route { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
