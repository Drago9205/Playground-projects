using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GreyhoundRace.Helpers;
using GreyhoundRace.Models;

namespace GreyhoundRace.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var raceMapper = new RaceEventRetriever();
            raceMapper.GetRaceEvents();
            return View();
        }

        public ActionResult GetViewData(string sortCriteria = "", bool isAscending = true)
        {
            var raceMapper = new RaceEventRetriever();
            var events = raceMapper.GetRaceEvents().ToArray();

            if (!string.IsNullOrEmpty(sortCriteria))
                SortData(events, sortCriteria, isAscending);

            return Json(events, JsonRequestBehavior.AllowGet);
        }

        private void SortData(IEnumerable<RaceEventModel> events, string sortCriteria = "", bool isAscending = true)
        {
            foreach (var vent in events)
            {
                if(sortCriteria == "Name" && isAscending)
                    vent.Entries = vent.Entries.OrderBy(e => e.Name);
                if (sortCriteria == "Name" && !isAscending)
                    vent.Entries = vent.Entries.OrderByDescending(e => e.Name);
                if (sortCriteria == "Odds" && isAscending)
                    vent.Entries = vent.Entries.OrderBy(e => e.OddsDecimal);
                if (sortCriteria == "Odds" && !isAscending)
                    vent.Entries = vent.Entries.OrderByDescending(e => e.OddsDecimal);
            }
        }
    }
}
