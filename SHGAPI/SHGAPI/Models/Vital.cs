using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Vital
{
    public int Id { get; set; }

    public int? BpDiastolic { get; set; }

    public int? BpSystolic { get; set; }

    public double Temperature { get; set; }

    public int? Pulse { get; set; }

    public int RespiratoryRate { get; set; }

    public int Spo2 { get; set; }

    public double? Weight { get; set; }

    public int PatientId { get; set; }

    public int EncounterId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public double? Height { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Encounter Encounter { get; set; } = null!;

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
