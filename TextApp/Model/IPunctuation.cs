﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Model
{
    interface IPunctuation:ISentenceItem
    {
        Symbol Simbols { get; }
    }
}
