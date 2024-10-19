using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Models
{
    public class TeamLeague
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int PointsGiven { get; set; }
        public int PointsReceived { get; set; }
        public int PointsDifference { get; set; }
    }
}
