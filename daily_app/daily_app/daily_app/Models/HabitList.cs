using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace daily_app.Models
{
    public class HabitsList
    {
        public HabitsList()
        {
            HabitsCollection = new List<Habit>();
            LastUpdateTimeChange();
        }
        public void CreateHabit(string description, ulong streak)
        {
            Habit h = new Habit() { HabitDescription = description, HabitStreak = streak, HabitLastModDate = LastUpdateTimeChange().AddDays(-1) };
            AddHabit(h);
        }
        public void ExportToJSON()
        {
            string jsonString = JsonSerializer.Serialize(this);
            
            //tests
            Debug.WriteLine("\n--------------JSON---PRINT--------------\n\n" + jsonString);
            Debug.WriteLine("\n------------HABITS---COUNTER------------\n\n" + ((App)App.Current).HabitsList.HabitsCollection.Count);

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HabitsListSaveFile.json");
            File.WriteAllText(filePath, jsonString);
        }

        private DateTime LastUpdateTimeChange()
        {
            return LastModDate = DateTime.Now;
        }
        private void AddHabit(Habit h)
        {
            HabitsCollection.Add(h);
            ((App)App.Current).HabitsList.ExportToJSON();
        }


        [JsonInclude]
        public DateTime LastModDate { get; set; }
        [JsonInclude]
        public List<Habit> HabitsCollection { get; set; }
    }
}
