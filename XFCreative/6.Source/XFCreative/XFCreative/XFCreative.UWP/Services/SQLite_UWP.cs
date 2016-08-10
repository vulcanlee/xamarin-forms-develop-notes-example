using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using XFCreative.Services;
using XFCreative.UWP.Services;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace XFCreative.UWP.Services
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }
        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            string path = GetDBPath();

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var path = GetDBPath();
            var asyncDb = new SQLiteAsyncConnection(path);
            // Return the database connection 
            return asyncDb;
        }
        #endregion

        public string GetDBPath()
        {
            var sqliteFilename = GlobalData.DBName;
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}
