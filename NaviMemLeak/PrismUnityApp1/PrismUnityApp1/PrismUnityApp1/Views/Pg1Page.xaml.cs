using System.Diagnostics;
using Xamarin.Forms;

namespace PrismUnityApp1.Views
{
    public partial class Pg1Page : ContentPage
    {
        public int Index { get; set; }
        ~Pg1Page()
        {
            Debug.WriteLine($"----------------- Release Pg1Page [{Index}]");
        }
        public Pg1Page()
        {
            InitializeComponent();

            Index = GlobalMember.Pg1Count;
            GlobalMember.Pg1Count++;
        }
    }
}
