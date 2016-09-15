using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFListView.ViewModels
{
    public class MyItemViewModel : BindableBase
    {

        #region FirstName
        private string firstName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set { this.SetProperty(ref this.firstName, value); }
        }
        #endregion

        #region LastName
        private string lastName;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
            set { this.SetProperty(ref this.lastName, value); }
        }
        #endregion

        #region Age
        private int age;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public int Age
        {
            get { return this.age; }
            set { this.SetProperty(ref this.age, value); }
        }
        #endregion

        public MyItemViewModel()
        {

        }
    }
}
