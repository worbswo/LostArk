﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Model
{
    public class Ablity
    {
        #region Field
        #endregion

        #region Property
        public Dictionary<string, List<int>> Items { get; set; } = new Dictionary<string, List<int>>();
        #endregion
    }
}
