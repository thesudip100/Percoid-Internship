using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class CallRequest
{
    public int Id { get; set; }

    public int? FromUserId { get; set; }

    public int? ToUserId { get; set; }

    public int? PatientId { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? FromUser { get; set; }

    public virtual PatientData? Patient { get; set; }

    public virtual User? ToUser { get; set; }
}
