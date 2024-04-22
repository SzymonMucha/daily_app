using System;
using System.Collections.Generic;
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
            Habit h = new Habit() { HabitDescription = description, HabitStreak = streak, HabitLastModDate = LastUpdateTimeChange() };
            AddHabit(h);
        }
        public void ExportToJSON()
        {
            Encoding unicode = Encoding.Unicode;

            string fileName = "HabitsListSaveFile.json";
            string jsonString = JsonSerializer.Serialize(this);
            FileStream openStream = File.OpenWrite(fileName);
            openStream.Write(unicode.GetBytes(jsonString), 0, unicode.GetByteCount(jsonString));
        }

        private DateTime LastUpdateTimeChange()
        {
            return LastModDate = DateTime.MinValue;
        }
        private void AddHabit(Habit h)
        { 
            HabitsCollection.Add(h);
        }


        [JsonInclude]
        public DateTime LastModDate { get; set; }
        [JsonInclude]
        public List<Habit> HabitsCollection { get; set; }
    }
}
