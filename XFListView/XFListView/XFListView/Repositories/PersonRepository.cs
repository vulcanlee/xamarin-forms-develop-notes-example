using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListView.Models;
using XFListView.ViewModels;

namespace XFListView.Repositories
{
    public class PersonRepository
    {
        public static ObservableCollection<PersonViewModel> SampleViewModel()
        {
            var fooItems = new ObservableCollection<PersonViewModel> {
                new PersonViewModel() { Name="Abigail", Birthday =new DateTime(1975, 1, 15), FavoriteColor=Color.Accent },
                new PersonViewModel() { Name="Bob", Birthday =new DateTime(1976, 2, 20), FavoriteColor=Color.Blue },
                new PersonViewModel() { Name="Yvonne", Birthday =new DateTime(1987, 1, 10), FavoriteColor=Color.Red },
                new PersonViewModel() { Name="Zachary", Birthday =new DateTime(1988, 2, 5), FavoriteColor=Color.Lime },
                new PersonViewModel() { Name="Bill", Birthday =new DateTime(1985, 11, 28), FavoriteColor=Color.Maroon },
                new PersonViewModel() { Name="Sheri", Birthday =new DateTime(1988, 8, 22), FavoriteColor=Color.Yellow },
            };
            return fooItems;
        }
        public static ObservableCollection<PersonWithButtonViewModel> SampleWithButtonViewModel()
        {
            var fooItems = new ObservableCollection<PersonWithButtonViewModel> {
                new PersonWithButtonViewModel() { Name="Abigail", Birthday =new DateTime(1975, 1, 15), FavoriteColor=Color.Accent },
                new PersonWithButtonViewModel() { Name="Bob", Birthday =new DateTime(1976, 2, 20), FavoriteColor=Color.Blue },
                new PersonWithButtonViewModel() { Name="Yvonne", Birthday =new DateTime(1987, 1, 10), FavoriteColor=Color.Red },
                new PersonWithButtonViewModel() { Name="Zachary", Birthday =new DateTime(1988, 2, 5), FavoriteColor=Color.Lime },
                new PersonWithButtonViewModel() { Name="Bill", Birthday =new DateTime(1985, 11, 28), FavoriteColor=Color.Maroon },
                new PersonWithButtonViewModel() { Name="Sheri", Birthday =new DateTime(1988, 8, 22), FavoriteColor=Color.Yellow },
                new PersonWithButtonViewModel() { Name="1Abigail", Birthday =new DateTime(1975, 1, 15), FavoriteColor=Color.Accent },
                new PersonWithButtonViewModel() { Name="1Bob", Birthday =new DateTime(1976, 2, 20), FavoriteColor=Color.Blue },
                new PersonWithButtonViewModel() { Name="1Yvonne", Birthday =new DateTime(1987, 1, 10), FavoriteColor=Color.Red },
                new PersonWithButtonViewModel() { Name="1Zachary", Birthday =new DateTime(1988, 2, 5), FavoriteColor=Color.Lime },
                new PersonWithButtonViewModel() { Name="1Bill", Birthday =new DateTime(1985, 11, 28), FavoriteColor=Color.Maroon },
                new PersonWithButtonViewModel() { Name="1Sheri", Birthday =new DateTime(1988, 8, 22), FavoriteColor=Color.Yellow },
                new PersonWithButtonViewModel() { Name="2Abigail", Birthday =new DateTime(1975, 1, 15), FavoriteColor=Color.Accent },
                new PersonWithButtonViewModel() { Name="2Bob", Birthday =new DateTime(1976, 2, 20), FavoriteColor=Color.Blue },
                new PersonWithButtonViewModel() { Name="2Yvonne", Birthday =new DateTime(1987, 1, 10), FavoriteColor=Color.Red },
                new PersonWithButtonViewModel() { Name="2Zachary", Birthday =new DateTime(1988, 2, 5), FavoriteColor=Color.Lime },
                new PersonWithButtonViewModel() { Name="2Bill", Birthday =new DateTime(1985, 11, 28), FavoriteColor=Color.Maroon },
                new PersonWithButtonViewModel() { Name="2Sheri", Birthday =new DateTime(1988, 8, 22), FavoriteColor=Color.Yellow },
            };
            return fooItems;
        }
    }
}
