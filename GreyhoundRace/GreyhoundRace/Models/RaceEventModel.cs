using System;
using System.Collections.Generic;

namespace GreyhoundRace.Models
{
    public class RaceEventModel
    {
        public int Id { get; set; }
        public int EventNumber { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime FinishTime { get; set; }
        public double Distance { get; set; }
        public string Name { get; set; }
        public IEnumerable<EntryModel> Entries { get; set; }
    }
}