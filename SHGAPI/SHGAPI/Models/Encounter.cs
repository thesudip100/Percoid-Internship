using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Encounter
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Reason { get; set; } = null!;

    public int PatientId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Service { get; set; }

    public string? Status { get; set; }

    public int? FacilityId { get; set; }

    public int? FollowUpId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Complient> Complients { get; set; } = new List<Complient>();

    public virtual ICollection<ConfirmDiagnosis> ConfirmDiagnoses { get; set; } = new List<ConfirmDiagnosis>();

    public virtual User? Doctor { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual HealthFacility? Facility { get; set; }

    public virtual Encounter? FollowUp { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Encounter> InverseFollowUp { get; set; } = new List<Encounter>();

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

    public virtual PatientData Patient { get; set; } = null!;

    public virtual ICollection<PhysicalExamination> PhysicalExaminations { get; set; } = new List<PhysicalExamination>();

    public virtual ICollection<ProvisionalDiagnosis> ProvisionalDiagnoses { get; set; } = new List<ProvisionalDiagnosis>();

    public virtual ICollection<RadiologyTest> RadiologyTests { get; set; } = new List<RadiologyTest>();

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();
}
