using daily_app.Models;
using daily_app.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

namespace daily_app
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void RefreshCommand() {
            OnAppearing();
            refreshView.IsRefreshing = false;
        }
        protected override void OnAppearing()
        {
            refreshView.Command = new Command(RefreshCommand);
            StackLayout childrenList = new StackLayout();
            bool deletedHabitStreak = false;
            int i = 0;

            foreach (var item in ((App)App.Current).HabitsList.HabitsCollection)
            {
                if (DateTime.Now.Day - item.HabitLastModDate.Day > 3) 
                {
                    item.HabitStreak = 0;
                    deletedHabitStreak = true;
                }
                StackLayout childStack = new StackLayout
                {
                    StyleClass = new[] { "HabitCard" },
                    Orientation = StackOrientation.Vertical
                };

                childStack.Children.Add(new Xamarin.Forms.Label {
                    Text = item.HabitDescription,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Label)),
                    TextColor = Color.FromHex("#F0EBF2"),
                    HorizontalOptions = LayoutOptions.Fill
                }); ;
                childStack.Children.Add(new Xamarin.Forms.Label { 
                    Text = "Daily streak: " + item.HabitStreak.ToString(), 
                    WidthRequest = 200,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Xamarin.Forms.Label)),
                    TextColor = Color.FromHex("#F0EBF2"),
                    HorizontalOptions = LayoutOptions.Start 
                });

                StackLayout buttonsStackLayout = new StackLayout { 
                    WidthRequest = 80,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End,
                    Orientation = StackOrientation.Horizontal
                };
                Button btnadd = new Button
                {
                    Text = "+",
                    HorizontalOptions = LayoutOptions.Start,
                    CornerRadius = 100,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                    StyleClass = new[] { "BtnAdd" },
                    StyleId = i.ToString(),
                    VerticalOptions = LayoutOptions.End
                };
                btnadd.Clicked += StreakIncrement;
                Button btndel = new Button
                {
                    Text = "x",
                    HorizontalOptions = LayoutOptions.End,
                    CornerRadius = 100,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                    StyleClass = new[] { "BtnAdd" },
                    StyleId = i.ToString(),
                    VerticalOptions = LayoutOptions.End
                };
                btndel.Clicked += HabitDelete;

                buttonsStackLayout.Children.Add(btnadd);
                buttonsStackLayout.Children.Add(btndel);

                childStack.Children.Add(buttonsStackLayout);

                Frame newCard = new Frame
                {
                    StyleClass = new[] { "HabitCardFrame" },
                    Content = childStack
                };

                childrenList.Children.Add(newCard);
                i++;
            }
            cardsOutput.Content = childrenList;

            if (deletedHabitStreak)
            {
                DisplayAlert(
                    "Alert",
                    "One or more of your habit streaks have been deleted due to your last activity associated with them was older than 3 days - don't let that happen again!",
                    "OK"
                );
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddHabitPage());

            /*string pageName;
            try {
                pageName = Navigation.NavigationStack.Last().Title;
            } catch {
                pageName = "";
            }
            if (pageName != "AddHabitPage")*/

            /*if (sender is Button button)
            {
                button.IsEnabled = false;
                Navigation.PushModalAsync(new AddHabitPage());
                System.Threading.Thread.Sleep(3000);
                button.IsEnabled = true;
            }*/
        }
        private async void StreakIncrement(object sender, EventArgs e)
        { 
            if (sender is Button button)
            {
                Habit h = ((App)App.Current).HabitsList.HabitsCollection.ElementAt(int.Parse(button.StyleId));

                if (h.HabitLastModDate.Day < DateTime.Now.Day)
                {
                    if (await DisplayAlert("Warning", "You can increase your streak only once a day - proceed?", "Yes", "No"))
                    {
                        h.HabitStreak++;
                        h.HabitLastModDate = DateTime.Now;
                        ((App)App.Current).HabitsList.LastModDate = h.HabitLastModDate;
                        ((App)App.Current).HabitsList.ExportToJSON();
                        OnAppearing();
                    }
                }
            }
            
        }
        private async void HabitDelete(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "You are going to delete this habit - proceed?", "Yes", "No"))
            {
                if (sender is Button button)
                {
                    ((App)App.Current).HabitsList.HabitsCollection.RemoveAt(int.Parse(button.StyleId));
                    ((App)App.Current).HabitsList.ExportToJSON();
                    OnAppearing();
                }
            }
        }
    }
}
