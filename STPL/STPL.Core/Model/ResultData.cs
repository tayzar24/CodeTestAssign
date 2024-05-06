﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Core.Model
{
    public class ResultData<T>
    {
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
