using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Entities
{
    public class Translation
    {
        public int EngId { get; set; }

        public string EngWord { get; set; }

        public int DId { get; set; }

        public string DWord { get; set; }

        public int GId { get; set; }

        public string GWord { get; set; }

        public int FId { get; set; }

        public string FWord { get; set; }
    }
}
