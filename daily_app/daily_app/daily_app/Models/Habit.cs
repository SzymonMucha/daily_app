using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace daily_app.Models
{
    public class Habit
    {
        [JsonInclude]
        private string _habitDescription;
        [JsonInclude]
        private ulong _habitStreak;
        [JsonInclude]
        private DateTime _habitLastModDate;

        public string HabitDescription
        {
            get { return _habitDescription; }
            set { _habitDescription = value; }
        }
        public ulong HabitStreak
        {
            get { return _habitStreak; }
            set { _habitStreak = value; }
        }
        public DateTime HabitLastModDate
        {
            get { return _habitLastModDate; }
            set { _habitLastModDate = value; }
        }
    }
}
