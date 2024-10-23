using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRecreationalLeague.Data.Repositories
{
    public class RefereeRepository
    {
        public static RefereeRepository GetInstance()
        {
            return App._serviceProvider.GetRequiredService<RefereeRepository>();
        }
        public RefereeRepository() { }
        //public bool Create(int userId)
        //{

        //}

    }
}
