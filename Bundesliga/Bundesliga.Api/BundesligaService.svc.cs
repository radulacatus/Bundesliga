using Bundesliga.Api.Contracts;
using Bundesliga.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bundesliga.Api
{
    public class BundesligaService : IBundesligaService
    {
        private readonly BundesligaContext _bundesligaContext;

        public BundesligaService()
        {
            _bundesligaContext = new BundesligaContext();
        }

        public List<Bundesliga.Api.Contracts.Team> GetAllTeams()
        {
            return _bundesligaContext.Teams.Select(x => new Bundesliga.Api.Contracts.Team
            {
                Id = x.Id,
                TeamName = x.TeamName
            }).ToList();
        }


        public Contracts.Game AddGame(Contracts.Game game)
        {
            var dbGame = new Bundesliga.DataAccess.Game
            {
                Date = DateTime.Now,
                Stage = game.Stage,
                Team1Goals = game.Team1Goals,
                Team1Id = game.Team1Id,
                Team2Goals = game.Team2Goals,
                Team2Id = game.Team2Id
            };

            if (_bundesligaContext.Games.Any(x =>
                (x.Team1Id == game.Team1Id || x.Team2Id == game.Team1Id || x.Team1Id == game.Team2Id || x.Team2Id == game.Team2Id) &&
                x.Stage == game.Stage))
            {
                throw new ArgumentException("game");
            }

            var insertedGame = _bundesligaContext.Games.Add(dbGame);
            _bundesligaContext.SaveChanges();

            game.Id = insertedGame.Id;
            return game;
        }


        public List<Contracts.Game> GetAllGames()
        {
            return _bundesligaContext.Games
                .Include("Teams,Teams1")
                .Select(x => new Bundesliga.Api.Contracts.Game
            {
                Id = x.Id,
                Stage = x.Stage,
                Team1Goals = x.Team1Goals,
                Team1Id = x.Team1Id,
                Team1Name = x.Teams.TeamName,
                Team2Goals = x.Team2Goals,
                Team2Id = x.Team2Id,
                Team2Name = x.Teams1.TeamName,
            }).ToList();
        }
    }
}
