using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? PlaceOfDelivery { get; set; }

    public string? OtherPlaceOfDelivery { get; set; }

    public string? BabyPresentation { get; set; }

    public string? TypeOfDelivery { get; set; }

    public int? NoOfLiveMaleBaby { get; set; }

    public int? NoOfLiveFemaleBaby { get; set; }

    public int? NoOfStillMaleBaby { get; set; }

    public int? NoOfStillFemaleBaby { get; set; }

    public int? NoOfFreshStillBirth { get; set; }

    public int? NoOfMaceratedStillBirth { get; set; }

    public string? DeliveryAttendedBy { get; set; }

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Refer { get; set; }

    public string? ReferReason { get; set; }

    public string? DoctorFeedback { get; set; }

    public string? Investigation { get; set; }

    public string? OtherProblems { get; set; }

    public string? Treatment { get; set; }

    public int? VitaminK { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<DeliveryChild> DeliveryChildren { get; set; } = new List<DeliveryChild>();

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
