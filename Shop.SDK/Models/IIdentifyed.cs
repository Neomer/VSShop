﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.SDK.Models
{
    public interface IIdentifyed
    {
        Guid ID { get; set; } 
    }
}