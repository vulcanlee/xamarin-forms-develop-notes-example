using System.Diagnostics;
using Xamarin.Forms;

namespace PrismUnityApp1.Views
{
    public partial class Pg2Page : ContentPage
    {
        public int Index { get; set; }
        ~Pg2Page()
        {
            Debug.WriteLine($"----------------- Release Pg2Page [{Index}]");
        }
        public Pg2Page()
        {
            InitializeComponent();

            Index = GlobalMember.Pg2Count;
            GlobalMember.Pg2Count++;
        }
    }
}
