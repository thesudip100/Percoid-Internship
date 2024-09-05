using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class HealthFacility
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Ward { get; set; } = null!;

    public string Palika { get; set; } = null!;

    public string District { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string InchargeName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Authority { get; set; }

    public string? AuthorityLevel { get; set; }

    public string? FacilityType { get; set; }

    public string? HfCode { get; set; }

    public string? Ownership { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<ChildImmunization> ChildImmunizations { get; set; } = new List<ChildImmunization>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<PatientData> Patients { get; set; } = new List<PatientData>();

    public virtual ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();

    public virtual ICollection<Roster> Rosters { get; set; } = new List<Roster>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
