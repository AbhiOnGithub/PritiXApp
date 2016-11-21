using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXDataAccess.Entities
{
    public class WordDictionaryItem
    {
        public int DictionaryId { get; set; }

        public IWord SourceWord { get; set; }

        public List<IWord> TranslatedWord { get; set; }
    }
}
