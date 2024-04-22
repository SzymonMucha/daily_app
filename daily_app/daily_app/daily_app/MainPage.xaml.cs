using daily_app.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
            StackLayout childrenList = new StackLayout();
            int i = 0;

            foreach (var item in ((App)App.Current).HabitsList.HabitsCollection)
            {
                StackLayout childStack = new StackLayout
                {
                    StyleClass = new[] { "HabitCard" },
                    Orientation = StackOrientation.Vertical
                };

                childStack.Children.Add(new Label {
                    Text = item.HabitDescription,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    TextColor = Color.FromHex("#F0EBF2"),
                    HorizontalOptions = LayoutOptions.Fill
                }); ;
                childStack.Children.Add(new Label { 
                    Text = "Daily streak: " + item.HabitStreak.ToString(), 
                    WidthRequest = 200,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.FromHex("#F0EBF2"),
                    HorizontalOptions = LayoutOptions.Start 
                });

                StackLayout buttonsStackLayout = new StackLayout { 
                    WidthRequest = 80,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End,
                    Orientation = StackOrientation.Horizontal
                };

                buttonsStackLayout.Children.Add(new Button { 
                    Text = "+", 
                    HorizontalOptions = LayoutOptions.Start,
                    CornerRadius = 100,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                    StyleClass = new[] {"BtnAdd"},
                    VerticalOptions = LayoutOptions.End
                }.Clicked += StreakIncrement);
                buttonsStackLayout.Children.Add(new Button
                {
                    Text = "x",
                    HorizontalOptions = LayoutOptions.End,
                    CornerRadius = 100,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                    StyleClass = new[] { "BtnAdd" },
                    VerticalOptions = LayoutOptions.End
                });

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
        private void StreakIncrement(object sender, EventArgs e)
        {
            
        }
    }
}
