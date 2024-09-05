using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Designation { get; set; }

    public int? FacilityId { get; set; }

    public int? UserRoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? NmcRegistrationNumber { get; set; }

    public string? Specialization { get; set; }

    public string? Username { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public int? CallStatus { get; set; }

    public virtual ICollection<AntenatalCare> AntenatalCareCreatedByNavigations { get; set; } = new List<AntenatalCare>();

    public virtual ICollection<AntenatalCare> AntenatalCareServiceProvidedByNavigations { get; set; } = new List<AntenatalCare>();

    public virtual ICollection<AntenatalCare> AntenatalCareUpdatedByNavigations { get; set; } = new List<AntenatalCare>();

    public virtual ICollection<Appointment> AppointmentCreatedByNavigations { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentDoctors { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentUpdatedByNavigations { get; set; } = new List<Appointment>();

    public virtual ICollection<CallRequest> CallRequestFromUsers { get; set; } = new List<CallRequest>();

    public virtual ICollection<CallRequest> CallRequestToUsers { get; set; } = new List<CallRequest>();

    public virtual ICollection<Complient> ComplientCreatedByNavigations { get; set; } = new List<Complient>();

    public virtual ICollection<Complient> ComplientUpdatedByNavigations { get; set; } = new List<Complient>();

    public virtual ICollection<ConfirmDiagnosis> ConfirmDiagnosisCreatedByNavigations { get; set; } = new List<ConfirmDiagnosis>();

    public virtual ICollection<ConfirmDiagnosis> ConfirmDiagnosisUpdatedByNavigations { get; set; } = new List<ConfirmDiagnosis>();

    public virtual ICollection<DeliveryChild> DeliveryChildCreatedByNavigations { get; set; } = new List<DeliveryChild>();

    public virtual ICollection<DeliveryChild> DeliveryChildUpdatedByNavigations { get; set; } = new List<DeliveryChild>();

    public virtual ICollection<Delivery> DeliveryCreatedByNavigations { get; set; } = new List<Delivery>();

    public virtual ICollection<Delivery> DeliveryUpdatedByNavigations { get; set; } = new List<Delivery>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual HealthFacility? Facility { get; set; }

    public virtual ICollection<Growth> GrowthCreatedByNavigations { get; set; } = new List<Growth>();

    public virtual ICollection<Growth> GrowthUpdatedByNavigations { get; set; } = new List<Growth>();

    public virtual ICollection<History> HistoryCreatedByNavigations { get; set; } = new List<History>();

    public virtual ICollection<History> HistoryUpdatedByNavigations { get; set; } = new List<History>();

    public virtual ICollection<HomeBabyPostnatalCare> HomeBabyPostnatalCareCreatedByNavigations { get; set; } = new List<HomeBabyPostnatalCare>();

    public virtual ICollection<HomeBabyPostnatalCare> HomeBabyPostnatalCareUpdatedByNavigations { get; set; } = new List<HomeBabyPostnatalCare>();

    public virtual ICollection<HomeMotherPostnatalCare> HomeMotherPostnatalCareCreatedByNavigations { get; set; } = new List<HomeMotherPostnatalCare>();

    public virtual ICollection<HomeMotherPostnatalCare> HomeMotherPostnatalCareUpdatedByNavigations { get; set; } = new List<HomeMotherPostnatalCare>();

    public virtual ICollection<ImmunizationHistory> ImmunizationHistoryCreatedByNavigations { get; set; } = new List<ImmunizationHistory>();

    public virtual ICollection<ImmunizationHistory> ImmunizationHistoryUpdatedByNavigations { get; set; } = new List<ImmunizationHistory>();

    public virtual ICollection<LabTest> LabTestCreatedByNavigations { get; set; } = new List<LabTest>();

    public virtual ICollection<LabTest> LabTestUpdatedByNavigations { get; set; } = new List<LabTest>();

    public virtual ICollection<Medication> MedicationCreatedByNavigations { get; set; } = new List<Medication>();

    public virtual ICollection<Medication> MedicationUpdatedByNavigations { get; set; } = new List<Medication>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PasswordReset> PasswordResets { get; set; } = new List<PasswordReset>();

    public virtual ICollection<PatientData> Patients { get; set; } = new List<PatientData>();

    public virtual ICollection<PhysicalExamination> PhysicalExaminationCreatedByNavigations { get; set; } = new List<PhysicalExamination>();

    public virtual ICollection<PhysicalExamination> PhysicalExaminationUpdatedByNavigations { get; set; } = new List<PhysicalExamination>();

    public virtual ICollection<PostnatalCare> PostnatalCareCreatedByNavigations { get; set; } = new List<PostnatalCare>();

    public virtual ICollection<PostnatalCare> PostnatalCareUpdatedByNavigations { get; set; } = new List<PostnatalCare>();

    public virtual ICollection<ProvisionalDiagnosis> ProvisionalDiagnosisCreatedByNavigations { get; set; } = new List<ProvisionalDiagnosis>();

    public virtual ICollection<ProvisionalDiagnosis> ProvisionalDiagnosisUpdatedByNavigations { get; set; } = new List<ProvisionalDiagnosis>();

    public virtual ICollection<RadiologyTest> RadiologyTestCreatedByNavigations { get; set; } = new List<RadiologyTest>();

    public virtual ICollection<RadiologyTest> RadiologyTestUpdatedByNavigations { get; set; } = new List<RadiologyTest>();

    public virtual ICollection<Roster> RosterCreatedByNavigations { get; set; } = new List<Roster>();

    public virtual ICollection<Roster> RosterUpdatedByNavigations { get; set; } = new List<Roster>();

    public virtual ICollection<Roster> RosterUsers { get; set; } = new List<Roster>();

    public virtual ICollection<SmsLog> SmsLogCreatedByNavigations { get; set; } = new List<SmsLog>();

    public virtual ICollection<SmsLog> SmsLogUpdatedByNavigations { get; set; } = new List<SmsLog>();

    public virtual ICollection<Treatment> TreatmentCreatedByNavigations { get; set; } = new List<Treatment>();

    public virtual ICollection<Treatment> TreatmentUpdatedByNavigations { get; set; } = new List<Treatment>();

    public virtual UserRole? UserRole { get; set; }

    public virtual ICollection<Vital> VitalCreatedByNavigations { get; set; } = new List<Vital>();

    public virtual ICollection<Vital> VitalUpdatedByNavigations { get; set; } = new List<Vital>();
}
