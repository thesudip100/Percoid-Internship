using System;
using System.Collections.Generic;

namespace SHGAPI.Models;

public partial class PasswordReset
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? Expires { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual User? User { get; set; }
}
