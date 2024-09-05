using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class HomeBabyPostnatalCare
{
    public int Id { get; set; }

    public string VisitingTime { get; set; } = null!;

    public string VisitTime { get; set; } = null!;

    public DateTime VisitDate { get; set; }

    public string Activities { get; set; } = null!;

    public int Respiration { get; set; }

    public double Temperature { get; set; }

    public string UmblicalArea { get; set; } = null!;

    public string Skin { get; set; } = null!;

    public string Eye { get; set; } = null!;

    public string Jundice { get; set; } = null!;

    public string UmblicalCream { get; set; } = null!;

    public string HealthCareProvider { get; set; } = null!;

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? BreastFeeding { get; set; }

    public string? Stool { get; set; }

    public string? Urination { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
