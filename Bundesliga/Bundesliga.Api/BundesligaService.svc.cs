using Bundesliga.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bundesliga.Api
{
    public class BundesligaService : IBundesligaService
    {
        public List<Team> GetAllTeams()
        {
            return new List<Team>
            {
                new Team {Id = 4, TeamName="Test"},
                new Team {Id = 6, TeamName="Test1"},
                new Team {Id = 9, TeamName="Test2"}
            };
        }
    }
}
