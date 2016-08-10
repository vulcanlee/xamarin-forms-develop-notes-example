using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XFCreative.Droid.Services;
using XFCreative.Services;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLite_Android))]
namespace XFCreative.Droid.Services
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
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

        public string GetDBPath()
        {
            var sqliteFilename = GlobalData.DBName;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
        #endregion
    }
}