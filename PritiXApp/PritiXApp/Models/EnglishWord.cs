using SQLite;

namespace PritiXApp.Models
{
    public class EnglishWord : IWord
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Word { get; set; }

        public int Index { get; set; }
    }
}
