﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGeneration
{
    public interface ITextLibrary : ILibrary
    {
        public string Source { get; init; }
    }
}