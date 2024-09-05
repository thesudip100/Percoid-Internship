using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Pregnancy
{
    public int Id { get; set; }

    public DateTime FirstVisit { get; set; }

    public string Gravida { get; set; } = null!;

    public string? Para { get; set; }

    public string? LastMensuratonPeriod { get; set; }

    public string? ExpectedDeliveryDate { get; set; }

    public int PatientId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? FacilityId { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<AntenatalCare> AntenatalCares { get; set; } = new List<AntenatalCare>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<DeliveryChild> DeliveryChildren { get; set; } = new List<DeliveryChild>();

    public virtual HealthFacility? Facility { get; set; }

    public virtual ICollection<HomeBabyPostnatalCare> HomeBabyPostnatalCares { get; set; } = new List<HomeBabyPostnatalCare>();

    public virtual ICollection<HomeMotherPostnatalCare> HomeMotherPostnatalCares { get; set; } = new List<HomeMotherPostnatalCare>();

    public virtual PatientData Patient { get; set; } = null!;

    public virtual ICollection<PostnatalCare> PostnatalCares { get; set; } = new List<PostnatalCare>();
}
