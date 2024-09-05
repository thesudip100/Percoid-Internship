using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class Document
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Path { get; set; }

    public int PatientId { get; set; }

    public int? EncounterId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Encounter? Encounter { get; set; }

    public virtual PatientData Patient { get; set; } = null!;
}
