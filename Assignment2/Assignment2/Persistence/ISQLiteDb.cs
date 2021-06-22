using SQLite;

namespace Assignment2.Persistence {
    public interface ISQLiteDb {
        SQLiteAsyncConnection GetConnection();
    }
}
