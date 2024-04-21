using daily_app.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace daily_app
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            foreach (var item in ((App)App.Current).HabitsList.HabitsCollection)
            {
                Frame newCard = new Frame
                {
                    StyleClass = new[] { "HabitCard" },
                    
                };
                cardsOutput.Content = (newCard);
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            /*string pageName;
            try {
                pageName = Navigation.NavigationStack.Last().Title;
            } catch {
                pageName = "";
            }
            if (pageName != "AddHabitPage")*/
            Navigation.PushModalAsync(new AddHabitPage());
            /*if (sender is Button button)
            {
                button.IsEnabled = false;
                Navigation.PushModalAsync(new AddHabitPage());
                System.Threading.Thread.Sleep(3000);
                button.IsEnabled = true;
            }*/
        }
    }
}
