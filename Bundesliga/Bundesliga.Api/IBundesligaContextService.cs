using Bundesliga.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bundesliga.Api
{
    public interface IBundesligaContextService
    {
        List<Team> GetAllTeams();

        Game InsertGame(Game game);

        List<Game> GetAllGames();

        List<Game> GetGamesByStage(int stage);

        void RemoveGame(int id);
    }
}
