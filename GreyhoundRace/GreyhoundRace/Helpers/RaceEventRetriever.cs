using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreyhoundRace.Models;
using Services;

namespace GreyhoundRace.Helpers
{
    public class RaceEventRetriever
    {
        public IEnumerable<RaceEventModel> GetRaceEvents()
        {
            string xmlPathData = HttpContext.Current.Server.MapPath("~/App_Data/race.xml");
            RaceXmlReader raceReader = new RaceXmlReader();
            var upcomingEvents = raceReader.GetUpCommingEvents(xmlPathData);

            return MapRaceEvents(upcomingEvents);
        }

        private IEnumerable<RaceEventModel> MapRaceEvents(UpcomingEvents upcommingEvents)
        {
            return upcommingEvents.Items.Select(item => new RaceEventModel
            {
                Id = int.Parse(item.ID), 
                Name = item.Name, Distance = double.Parse(item.Distance), 
                EventDate = DateTime.Parse(item.EventTime), 
                FinishTime = DateTime.Parse(item.FinishTime), 
                EventNumber = int.Parse(item.EventNumber), 
                Entries = MapEntries(item.Entry)
            });
        }

        private IEnumerable<EntryModel> MapEntries(IEnumerable<UpcomingEventsRaceEventEntry> entries)
        {
            return entries.Select(entry => new EntryModel
            {
                Id = int.Parse(entry.ID), 
                Name = entry.Name, 
                OddsDecimal = double.Parse(entry.OddsDecimal)
            });
        }
    }
}