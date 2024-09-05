using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Date { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? EncounterId { get; set; }

    public int? PregnancyId { get; set; }

    public int? FacilityId { get; set; }

    public string? Service { get; set; }

    public int? CallDuration { get; set; }

    public int? ChildImmunizationId { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public int? Consent { get; set; }

    public virtual ChildImmunization? ChildImmunization { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User Doctor { get; set; } = null!;

    public virtual Encounter? Encounter { get; set; }

    public virtual HealthFacility? Facility { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy? Pregnancy { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
