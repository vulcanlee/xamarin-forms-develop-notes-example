using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETStdUserDialogs.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand LoadCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            LoadCommand = new DelegateCommand(async () =>
            {
                using (var dlg = UserDialogs.Instance.Loading("Test Progress"))
                {
                    await Task.Delay(2000);
                }
            });
        }
    }
}
