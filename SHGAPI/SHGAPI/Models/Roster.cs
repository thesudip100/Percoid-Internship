using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Roster
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FacilityId { get; set; }

    public DateTime Date { get; set; }

    public string FromTime { get; set; } = null!;

    public string ToTime { get; set; } = null!;

    public string Service { get; set; } = null!;

    public int Status { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual HealthFacility Facility { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
