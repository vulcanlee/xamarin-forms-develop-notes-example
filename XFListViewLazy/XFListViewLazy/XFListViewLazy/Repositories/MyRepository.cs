using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFListViewLazy.Models;

namespace XFListViewLazy.Repositories
{
    public class MyRepository
    {
        public const int CycleLength = 20;
        public List<MyModel> Items = new List<MyModel>();
        private static MyRepository instance;
        private MyRepository()
        {
            this.GetNext(0);
        }

        public static MyRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MyRepository();
            }
            return instance;
        }

        public List<MyModel> GetNext(int lastID)
        {
            List<MyModel> foo = new List<MyModel>();
            for (int i = lastID; i < lastID+MyRepository.CycleLength; i++)
            {
                var fooItem = new MyModel()
                {
                    ID = i,
                    Name = $"Name {i}",
                    Current = DateTime.UtcNow.AddDays(i),
                };
                Items.Add(fooItem);
                foo.Add(fooItem);
            }
            return foo;
        }
    }
}
