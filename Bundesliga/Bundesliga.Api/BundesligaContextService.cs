using Bundesliga.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bundesliga.Api
{
    public class BundesligaContextService : IBundesligaContextService
    {
        private readonly IRepository<Game> _gameRepository;

        private readonly IRepository<Team> _teamRepository;

        public BundesligaContextService(IRepository<Game> gameRepository, IRepository<Team> teamRepository)
        {
            _gameRepository = gameRepository;
            _teamRepository = teamRepository;
        }

        public List<Contracts.Team> GetAllTeams()
        {
            return _teamRepository.All().Select(x => new Bundesliga.Api.Contracts.Team
            {
                Id = x.Id,
                TeamName = x.TeamName
            }).ToList();
        }

        public Contracts.Game InsertGame(Contracts.Game game)
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

            var insertedId = _gameRepository.Save(dbGame);
            game.Id = insertedId;
            return game;
        }

        public List<Contracts.Game> GetAllGames()
        {
            return _gameRepository.All().Select(Convert).ToList();
        }

        public List<Contracts.Game> GetGamesByStage(int stage)
        {
            return _gameRepository.All().Where(x => x.Stage == stage).Select(Convert).ToList();
        }

        private static Contracts.Game Convert(Game x)
        {
            return new Bundesliga.Api.Contracts.Game
            {
                Id = x.Id,
                Stage = x.Stage,
                Team1Goals = x.Team1Goals,
                Team1Id = x.Team1Id,
                Team1Name = x.Team1.TeamName,
                Team2Goals = x.Team2Goals,
                Team2Id = x.Team2Id,
                Team2Name = x.Team2.TeamName,
            };
        }
    }
}