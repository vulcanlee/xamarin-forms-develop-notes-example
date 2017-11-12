using MyPrismPack2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrismPack2.Repositories
{
    public class MyRepository
    {
        public IEnumerable<SampleItem> GetSampleList()
        {
            Random rm = new Random();
            var fooList = new List<SampleItem>();
            for (int i = 0; i < 100; i++)
            {
                fooList.Add(new SampleItem()
                {
                    Id = i,
                    Title = $"Item Name {i}",
                    Cost = rm.Next(100, 99999),
                    ShowDate = DateTime.Now.AddDays(rm.NextDouble() * 14),
                    DateDetail = ""
                });
            }
            return fooList;
        }
    }
}
