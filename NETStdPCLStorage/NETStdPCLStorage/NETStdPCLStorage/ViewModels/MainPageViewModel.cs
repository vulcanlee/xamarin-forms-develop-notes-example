using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETStdPCLStorage.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {


        #region MyEntry
        private string _MyEntry = "";
        /// <summary>
        /// MyEntry
        /// </summary>
        public string MyEntry
        {
            get { return this._MyEntry; }
            set { this.SetProperty(ref this._MyEntry, value); }
        }
        #endregion

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CleanCommand { get; set; }
        public DelegateCommand LoadCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            SaveCommand = new DelegateCommand(async () =>
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
                    CreationCollisionOption.OpenIfExists);
                IFile file = await folder.CreateFileAsync("answer.txt",
                    CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(MyEntry);
            });
            CleanCommand = new DelegateCommand(() =>
            {
                MyEntry = "";
            });
            LoadCommand = new DelegateCommand(async () =>
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
                    CreationCollisionOption.OpenIfExists);
                IFile file = await folder.GetFileAsync("answer.txt");
                MyEntry = await file.ReadAllTextAsync();
            });
        }
    }
}
