using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bundesliga.Web.Models
{
    public class RankingItem
    {
        public string TeamName { get; set; }

        public int PlayedGames { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int Points { get; set; }
    }
}