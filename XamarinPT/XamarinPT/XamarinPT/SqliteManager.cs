using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace XamarinPT
{
    class SqliteManager
    {
        private static SQLiteConnection sqlc = new SQLiteConnection(FileSystem.Current.LocalStorage.Path + "\\" + Resources.DB_NAME);

        private static SqliteManager _instance;
        public static SqliteManager Instance()
        {
            _instance = _instance ?? (_instance = new SqliteManager());
            return _instance;
        }

        public static int CreateTable<T>()
        {
            return sqlc.CreateTable<T>();
        }

        public static List<T> GetAllTable<T>() where T : new()
        {
            return sqlc.Table<T>().ToList();
        }

        public static int Insert(object input)
        {
            return sqlc.Insert(input);
        }

        public static int InsertAll(List<object> input)
        {
            return sqlc.InsertAll(input);
        }

        public static int Update(object input)
        {
            return sqlc.Update(input);
        }

        public static int UpdateAll(List<object> input)
        {
            return sqlc.UpdateAll(input);
        }

        public static int Delete(object input)
        {
            return sqlc.Delete(input);
        }

        public static int DeleteAllTable<T>()
        {
            return sqlc.DeleteAll<T>();
        }
    }
}
