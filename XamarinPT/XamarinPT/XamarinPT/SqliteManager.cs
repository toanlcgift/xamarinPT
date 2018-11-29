using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XamarinPT
{
    class SqliteManager
    {
        private static SQLiteConnection sqlc = new SQLiteConnection(Path.Combine(FileSystem.Current.LocalStorage.Path, Resources.DB_NAME));

        private static SqliteManager _instance;
        public static SqliteManager Instance()
        {
            _instance = _instance ?? (_instance = new SqliteManager());
            return _instance;
        }

        public int CreateTable<T>()
        {
            return sqlc.CreateTable<T>();
        }

        public List<T> GetAllTable<T>() where T : new()
        {
            return sqlc.Table<T>().ToList();
        }

        public int Insert(object input)
        {
            return sqlc.Insert(input);
        }

        public int InsertAll(List<object> input)
        {
            return sqlc.InsertAll(input);
        }

        public int Update(object input)
        {
            return sqlc.Update(input);
        }

        public int UpdateAll(List<object> input)
        {
            return sqlc.UpdateAll(input);
        }

        public int Delete(object input)
        {
            return sqlc.Delete(input);
        }

        public int DeleteAllTable<T>()
        {
            return sqlc.DeleteAll<T>();
        }
    }
}
