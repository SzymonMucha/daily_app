using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace daily_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginPage : ContentPage
    {
        public loginPage()
        {
            InitializeComponent();
        }
        public void NewAccountCommand()
        {
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}