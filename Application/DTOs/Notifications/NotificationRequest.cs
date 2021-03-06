﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Notifications
{
    public class NotificationRequest
    {
        public string DeviceId { get; set; }

        public string NotificationCode { get; set; }

        public string Message { get; set; }

        public int Priority { get; set; }

        public string OptionalMessage { get; set; }
    }
}
