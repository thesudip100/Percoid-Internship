using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class PatientData
{
    public int Id { get; set; }

    public string PatientId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Caste { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string District { get; set; } = null!;

    public string Palika { get; set; } = null!;

    public int Ward { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Service { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? NationalId { get; set; }

    public string? NhisNumber { get; set; }

    public int? AssignedUserId { get; set; }

    public int? FacilityId { get; set; }

    public string? Status { get; set; }

    public DateTime? Dob { get; set; }

    public string AgeUnit { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual ICollection<AntenatalCare> AntenatalCares { get; set; } = new List<AntenatalCare>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? AssignedUser { get; set; }

    public virtual ICollection<CallRequest> CallRequests { get; set; } = new List<CallRequest>();

    public virtual ICollection<ChildImmunization> ChildImmunizations { get; set; } = new List<ChildImmunization>();

    public virtual ICollection<Complient> Complients { get; set; } = new List<Complient>();

    public virtual ICollection<ConfirmDiagnosis> ConfirmDiagnoses { get; set; } = new List<ConfirmDiagnosis>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<DeliveryChild> DeliveryChildren { get; set; } = new List<DeliveryChild>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual HealthFacility? Facility { get; set; }

    public virtual ICollection<Growth> Growths { get; set; } = new List<Growth>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<HomeBabyPostnatalCare> HomeBabyPostnatalCares { get; set; } = new List<HomeBabyPostnatalCare>();

    public virtual ICollection<HomeMotherPostnatalCare> HomeMotherPostnatalCares { get; set; } = new List<HomeMotherPostnatalCare>();

    public virtual ICollection<ImmunizationHistory> ImmunizationHistories { get; set; } = new List<ImmunizationHistory>();

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

    public virtual ICollection<PhysicalExamination> PhysicalExaminations { get; set; } = new List<PhysicalExamination>();

    public virtual ICollection<PostnatalCare> PostnatalCares { get; set; } = new List<PostnatalCare>();

    public virtual ICollection<Pregnancy> Pregnancies { get; set; } = new List<Pregnancy>();

    public virtual ICollection<ProvisionalDiagnosis> ProvisionalDiagnoses { get; set; } = new List<ProvisionalDiagnosis>();

    public virtual ICollection<RadiologyTest> RadiologyTests { get; set; } = new List<RadiologyTest>();

    public virtual ICollection<SmsLog> SmsLogs { get; set; } = new List<SmsLog>();

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

    public virtual ICollection<Vital> Vitals { get; set; } = new List<Vital>();
}
