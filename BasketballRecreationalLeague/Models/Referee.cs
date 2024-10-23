using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public RefereeType RefereeType { get; set; }
    }
    public enum RefereeType
    {
        ScoreTableReferee,
        FieldReferee
    }

}
