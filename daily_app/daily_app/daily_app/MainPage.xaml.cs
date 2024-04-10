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
        private string _habitDescription;
        private ulong _habitStreak;
        private DateTime _habitLastModDate;

        public string HabitDescription { 
            get { return _habitDescription; }
            set { _habitDescription = value; }
        }
        public ulong HabitStreak { 
            get { return _habitStreak; }
            set { _habitStreak = value; }
        }
        public DateTime HabitLastModDate { 
            get { return _habitLastModDate; }
            set { _habitLastModDate = value; }
        }
    }
    public class HabitsList { 
        public DateTime _lastModDate;
        public List<Habit> _habitsCollection;

        private DateTime LastUpdateTimeChange() {
            return _lastModDate = DateTime.MinValue;
        }
        public HabitsList() {
            _habitsCollection = new List<Habit>();
            LastUpdateTimeChange();
        }
        private void AddHabit(Habit h) { 
            h.HabitLastModDate = LastUpdateTimeChange();
            _habitsCollection.Add(h);
        }
        public void CreateHabit(string description) {
            Habit h = new Habit() { HabitDescription = description, HabitStreak = 0, HabitLastModDate = new DateTime(0000, 0, 0, 0, 0, 0) };
            AddHabit(h);
        }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
