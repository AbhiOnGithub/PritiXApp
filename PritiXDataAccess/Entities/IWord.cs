using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Entities
{
    public interface IWord
    {
        int Id { get; set; }

        string Word { get; set; }

        int Index { get; set; }
    }
}
