using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class HomeMotherPostnatalCare
{
    public int Id { get; set; }

    public string VisitingTime { get; set; } = null!;

    public string VisitTime { get; set; } = null!;

    public DateTime VisitDate { get; set; }

    public double Pulse { get; set; }

    public double BodyTemperature { get; set; }

    public int BpSystolic { get; set; }

    public int BpDiastolic { get; set; }

    public string PpHeamorage { get; set; } = null!;

    public string PpHeamorageTreatment { get; set; } = null!;

    public string BreastExamination { get; set; } = null!;

    public string Edema { get; set; } = null!;

    public string ExaminationOfUterus { get; set; } = null!;

    public string VaginalExamination { get; set; } = null!;

    public string UrinationDifficulties { get; set; } = null!;

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? VaginalDischarge { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
