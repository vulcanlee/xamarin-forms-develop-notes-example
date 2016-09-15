using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFListView.Models
{
    public class Person
    {
        public Person(string name, DateTime birthday, Color favoriteColor)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.FavoriteColor = favoriteColor;
        }

        public string Name { private set; get; }

        public DateTime Birthday { private set; get; }

        public Color FavoriteColor { private set; get; }
    };
}
