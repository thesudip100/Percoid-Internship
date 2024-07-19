﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class EmailSetttings
    {
        public class EmailSettings
        {
            public string? SmtpServer { get; set; }
            public int? SmtpPort { get; set; }
            public string? SenderEmail { get; set; }
            public string? SenderName { get; set; }
            public string? SenderPassword { get; set; }
        }

    }
}