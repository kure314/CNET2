﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtextGUI.WebChecker
{
    public class Webs
    {
        public static ConcurrentDictionary<string, bool> WebToCheck { get; set; } = new();
             
    }
}
