using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class PostnatalCare
{
    public int Id { get; set; }

    public string VisitingTime { get; set; } = null!;

    public string VisitTime { get; set; } = null!;

    public DateTime VisitDate { get; set; }

    public string ConditionOfMother { get; set; } = null!;

    public string ConditionOfBaby { get; set; } = null!;

    public string Treatment { get; set; } = null!;

    public string MedicalAdvice { get; set; } = null!;

    public string FamilyPlanningServices { get; set; } = null!;

    public string Complications { get; set; } = null!;

    public string DangerSignsOnMother { get; set; } = null!;

    public string DangerSignsOnBaby { get; set; } = null!;

    public string CheckupAttendedBy { get; set; } = null!;

    public string NewBornBabyStatus { get; set; } = null!;

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Refer { get; set; }

    public string? ReferReason { get; set; }

    public string? DoctorFeedback { get; set; }

    public int? Calcium { get; set; }

    public int? IronTablet { get; set; }

    public string? Investigation { get; set; }

    public string? OtherProblems { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public int? ServiceProvidedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
