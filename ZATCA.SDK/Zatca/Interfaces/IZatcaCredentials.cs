﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZATCA.SDK.Helpers.Zatca
{
    public interface IZatcaCredentials
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
