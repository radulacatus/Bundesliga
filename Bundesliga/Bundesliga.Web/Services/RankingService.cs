using Bundesliga.DataAccess;
using Bundesliga.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bundesliga.Web.Services
{
    public class RankingService : IRankingService
    {
        private readonly IRepository<Game> _gameRepository;

        private readonly IRepository<Team> _teamRepository;

        public RankingService(IRepository<Game> gameRepository, IRepository<Team> teamRepository)
        {
            _gameRepository = gameRepository;
            _teamRepository = teamRepository;
        }

        public List<RankingItem> GetStandings()
        {
            var teamsDictionary = _teamRepository.All().ToDictionary(k => k.Id, x => new RankingItem { TeamName = x.TeamName });
            var allGames = _gameRepository.All();

            foreach (var game in allGames)
            {
                if (game.Team1Goals > game.Team2Goals)
                {
                    AddWin(teamsDictionary, game.Team1Id);
                    AddLoss(teamsDictionary, game.Team2Id);
                }
                else if (game.Team1Goals == game.Team2Goals)
                {
                    AddDraw(teamsDictionary, game.Team1Id);
                    AddDraw(teamsDictionary, game.Team2Id);
                }
                else
                {
                    AddLoss(teamsDictionary, game.Team1Id);
                    AddWin(teamsDictionary, game.Team2Id);
                }
            }

            return teamsDictionary.Values.ToList();
        }

        private static void AddWin(Dictionary<int, RankingItem> teamsDictionary, int teamId)
        {
            var rankingItem = GetRankingItem(teamsDictionary, teamId);
            rankingItem.Wins++;
            rankingItem.PlayedGames++;
            rankingItem.Points += 3;
        }

        private static void AddLoss(Dictionary<int, RankingItem> teamsDictionary, int teamId)
        {
            var rankingItem = GetRankingItem(teamsDictionary, teamId);
            rankingItem.Losses++;
            rankingItem.PlayedGames++;
        }

        private static void AddDraw(Dictionary<int, RankingItem> teamsDictionary, int teamId)
        {
            var rankingItem = GetRankingItem(teamsDictionary, teamId);
            rankingItem.Draws++;
            rankingItem.PlayedGames++;
            rankingItem.Points++;
        }

        private static RankingItem GetRankingItem(Dictionary<int, RankingItem> teamsDictionary, int teamId)
        {
            RankingItem rankingItem;
            if (!teamsDictionary.TryGetValue(teamId, out rankingItem))
            {
                throw new ArgumentOutOfRangeException("teamId");
            }
            return rankingItem;
        }
    }
}