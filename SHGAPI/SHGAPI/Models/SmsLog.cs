using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class SmsLog
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime ScheduleDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? SmsBody { get; set; }

    public int Status { get; set; }

    public string? Phone { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual PatientData Patient { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
