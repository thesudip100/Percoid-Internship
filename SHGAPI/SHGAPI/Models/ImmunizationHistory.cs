using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class ImmunizationHistory
{
    public int Id { get; set; }

    public string VaccineName { get; set; } = null!;

    public DateTime Date { get; set; }

    public int? Vaccinated { get; set; }

    public DateTime? VaccinatedDate { get; set; }

    public int PatientId { get; set; }

    public int ChildImmunizationId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public string? Aefi { get; set; }

    public virtual ChildImmunization ChildImmunization { get; set; } = null!;

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
