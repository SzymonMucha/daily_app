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
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            try
            {
                string fileName = "HabitsListSaveFile.json";
                FileStream openStream = File.OpenRead(fileName);
                HabitsList = JsonSerializer.Deserialize<HabitsList>(openStream);
            }
            catch
            {
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
