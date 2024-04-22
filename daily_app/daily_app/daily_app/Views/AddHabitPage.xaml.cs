using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace daily_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHabitPage : ContentPage
    {
        public AddHabitPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (habitName.Text != "" && habitStreak.Text != "" && habitName.Text != null && habitStreak.Text != null)
            {
                string hName = habitName.Text;
                ulong hStreak = ulong.Parse(habitStreak.Text);

                ((App)App.Current).HabitsList.CreateHabit(hName, hStreak);
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Alert", "Some of the fields are empty, fix it!", "OK");
            }
        }
    }
}