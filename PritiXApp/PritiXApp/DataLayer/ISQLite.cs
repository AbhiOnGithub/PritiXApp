using SQLite;

namespace PritiXApp.DataLayer
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
