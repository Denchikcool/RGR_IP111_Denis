﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public interface ICollectionLoader
    {
        IEnumerable<Full_Elements> Load(string path);
    }
}
