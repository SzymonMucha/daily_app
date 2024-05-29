using daily_app.Models;
using daily_app.Views;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace daily_app
{
    public partial class App : Application
    {
        public HabitsList HabitsList { get; set; }
        public User user { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            try {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HabitsListSaveFile.json");

                string jsonData = File.ReadAllText(filePath);
                HabitsList = JsonSerializer.Deserialize<HabitsList>(jsonData);
            }
            catch {
                HabitsList = new HabitsList();
            }
        }

        protected override void OnSleep()
        { 
        }

        protected override void OnResume()
        {
        }
    }
}
