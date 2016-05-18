using Bundesliga.DataAccess;
using Bundesliga.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bundesliga.Web.Services
{
    public interface IRankingService
    {
        List<RankingItem> GetStandings();
    }
}