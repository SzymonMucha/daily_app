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
    public class Habit {
        private int habitId;
        private string habitDescription;
        private ulong habitStreak;
        private DateTime habitLastModDate;

        //setters and getters here

    }
    public class HabitsList { 
        public DateTime lastModDate;
        public Habit[] HabitsCollection;

    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
