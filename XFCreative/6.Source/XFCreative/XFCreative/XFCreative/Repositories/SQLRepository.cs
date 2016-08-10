using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCreative.Services;

namespace XFCreative.Repositories
{
    public class SQLRepository<T> where T : class, new()
    {
        static object locker = new object();
        public string DBPath { get; set; }
        //public SQLiteConnection database;
        public SQLiteAsyncConnection databaseAsync;
        public SQLRepository()
        {
            //database = DependencyService.Get<ISQLite>().GetConnection();
            databaseAsync = DependencyService.Get<ISQLite>().GetConnectionAsync();
            //DBPath = database.DatabasePath;
            //DBPath = databaseAsync.DatabasePath;
            // create the tables
            //database.CreateTable<T>();
            databaseAsync.CreateTableAsync<T>().Wait(); ;
        }

        #region 非同步的 SQLiteAsyncConnection 用法
        public async Task<List<T>> GetAllAsync()
        {
            return await databaseAsync.Table<T>().ToListAsync();
        }

        public async Task<int> InsertAsync(T item)
        {
            return await databaseAsync.InsertAsync(item);
        }

        public async Task<int> UpdateAsync(T item)
        {
            return await databaseAsync.UpdateAsync(item);
        }

        public async Task<int> DeleteAsync(T item)
        {
            return await databaseAsync.DeleteAsync(item);
        }

        #endregion

        //#region 使用同步的 SQLiteConnection ，轉換成為非同步的用法
        //public Task<List<T>> GetAllAsync()
        //{
        //    lock (locker)
        //    {
        //        var tcs = new TaskCompletionSource<List<T>>();
        //        Task.Run(() =>
        //        {
        //            //var fooItems = (from i in database.Table<T>() select i).ToList();
        //            var fooItems = database.Table<T>().ToList();
        //            tcs.SetResult(fooItems);
        //        });
        //        return tcs.Task;
        //    }
        //}

        //public Task InsertAsync(T item)
        //{
        //    lock (locker)
        //    {
        //        return Task.Run(() =>
        //        {
        //            database.Insert(item);
        //        });
        //    }
        //}

        //public Task UpdateAsync(T item)
        //{
        //    lock (locker)
        //    {
        //        return Task.Run(() =>
        //        {
        //            database.Update(item);
        //        });
        //    }
        //}

        //public Task DeleteAsync(T item)
        //{
        //    lock (locker)
        //    {
        //        return Task.Run(() =>
        //        {
        //            database.Delete(item);
        //        });
        //    }
        //}

        //#endregion
    }
}
