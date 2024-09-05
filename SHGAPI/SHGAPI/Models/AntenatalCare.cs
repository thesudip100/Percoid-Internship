using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class AntenatalCare
{
    public int Id { get; set; }

    public DateTime? AncVisitDate { get; set; }

    public string? VisitingTimeWeek { get; set; }

    public string? VisitingTimeMonth { get; set; }

    public double? MotherWeight { get; set; }

    public int? Anemia { get; set; }

    public int? Edema { get; set; }

    public int? Systolic { get; set; }

    public int? Diastolic { get; set; }

    public string? PregnancyPeriodWeek { get; set; }

    public double? FundalHeight { get; set; }

    public string? BabyPresentation { get; set; }

    public int? HeartRate { get; set; }

    public string? OtherProblems { get; set; }

    public string? Treatment { get; set; }

    public string? MedicalAdvice { get; set; }

    public DateTime? NextVisitSchedule { get; set; }

    public int? IronTablet { get; set; }

    public int? Albendazole { get; set; }

    public string? TdVaccination { get; set; }

    public string? ObstrcutiveComplications { get; set; }

    public string? DangerSign { get; set; }

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Document { get; set; }

    public string? DoctorFeedback { get; set; }

    public int? Calcium { get; set; }

    public int? FolicAcid { get; set; }

    public string? Refer { get; set; }

    public string? ReferReason { get; set; }

    public string? Investigation { get; set; }

    public int? ServiceProvidedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? ServiceProvidedByNavigation { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
