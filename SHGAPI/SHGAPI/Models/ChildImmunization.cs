using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class ChildImmunization
{
    public int Id { get; set; }

    public string? MothersName { get; set; }

    public string? FathersName { get; set; }

    public double? WeightAtBirth { get; set; }

    public int PatientId { get; set; }

    public int? FacilityId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual HealthFacility? Facility { get; set; }

    public virtual ICollection<Growth> Growths { get; set; } = new List<Growth>();

    public virtual ICollection<ImmunizationHistory> ImmunizationHistories { get; set; } = new List<ImmunizationHistory>();

    public virtual PatientData Patient { get; set; } = null!;
}
