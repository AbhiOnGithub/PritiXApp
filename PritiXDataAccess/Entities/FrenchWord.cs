﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Entities
{
    public class FrenchWord : IWord
    {
        public int Id { get; set; }

        public string Word { get; set; }

        public int Index { get; set; }
    }
}
