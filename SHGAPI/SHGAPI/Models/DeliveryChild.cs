using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class DeliveryChild
{
    public int Id { get; set; }

    public int DeliveryId { get; set; }

    public double? WeigntOfBaby { get; set; }

    public string? NewBornBabyStatus { get; set; }

    public int PatientId { get; set; }

    public int PregnancyId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual PatientData Patient { get; set; } = null!;

    public virtual Pregnancy Pregnancy { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
