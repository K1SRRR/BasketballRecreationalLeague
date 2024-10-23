using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasketballRecreationalLeague.DTO
{
    public class LeagueDTO
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public string Season { get; set; }
        public string PrintLeague
        {
            get
            {
                return Grade + " - " + Season;
            }
        }
    }
}
