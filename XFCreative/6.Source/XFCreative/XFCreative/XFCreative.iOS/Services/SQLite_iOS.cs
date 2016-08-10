using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using Xamarin.Forms;
using XFCreative.iOS.Services;
using XFCreative.Services;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace XFCreative.iOS.Services
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            var path = GetDBPath();

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
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            return path;
        }
    }
}
