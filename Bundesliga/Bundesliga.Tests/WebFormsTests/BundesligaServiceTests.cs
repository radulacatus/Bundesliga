using Bundesliga.Api;
using Bundesliga.Api.Contracts;
using Bundesliga.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;

namespace Bundesliga.Tests.ApiTests
{
    [TestClass]
    public class RankingServiceTests
    {
        public DataAccess.BundesligaContext _mockContext { get; set; }
     
        public IRankingService _rankingService { get; set; }

        [TestMethod]
        public void GivenGetStandingsIsCalled_WhenGamesArePresent_ThenPointsAreAddedCorrectly()
        {
            var rankingItems = _rankingService.GetStandings().OrderByDescending(x => x.Points).ToArray();

            Assert.AreEqual(rankingItems.Length, 4);
            Assert.AreEqual(rankingItems[0].Points, 6);
            Assert.AreEqual(rankingItems[1].Points, 4);
            Assert.AreEqual(rankingItems[2].Points, 1);
            Assert.AreEqual(rankingItems[3].Points, 0);
        }

        [TestInitialize]
        public void SetUp()
        {
            var teams = new List<DataAccess.Team>
            {
                new DataAccess.Team{Id = 1}, // 1 d 1 l = 1 p
                new DataAccess.Team{Id = 2}, // 1 d 1 v = 4 p
                new DataAccess.Team{Id = 3}, // 2 v = 6 p
                new DataAccess.Team{Id = 4}, // 2 l = 0 p
            }.AsQueryable();

            var games = new List<DataAccess.Game>
            {
                new DataAccess.Game { Team1Id = 1, Team2Id = 2, Team1Goals = 1, Team2Goals = 1, Stage = 1 },
                new DataAccess.Game { Team1Id = 3, Team2Id = 4, Team1Goals = 1, Team2Goals = 0, Stage = 1 },
                new DataAccess.Game { Team1Id = 1, Team2Id = 3, Team1Goals = 0, Team2Goals = 1, Stage = 1 },
                new DataAccess.Game { Team1Id = 2, Team2Id = 4, Team1Goals = 1, Team2Goals = 0, Stage = 1 },
            }.AsQueryable();

            var teamsDbSet = SetupMockDbSet<DataAccess.Team>(teams);
            var gamesDbSet = SetupMockDbSet<DataAccess.Game>(games);

            _mockContext = Substitute.For<DataAccess.BundesligaContext>();
            _mockContext.Teams.Returns(teamsDbSet);
            _mockContext.Games.Returns(gamesDbSet);

            _rankingService = new RankingService(_mockContext);
        }

        private IDbSet<T> SetupMockDbSet<T>(IQueryable<T> data)
            where T : class
        {
            var mockDbSet = Substitute.For<IDbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)mockDbSet).Provider.Returns(data.Provider);
            ((IQueryable<T>)mockDbSet).Expression.Returns(data.Expression);
            ((IQueryable<T>)mockDbSet).ElementType.Returns(data.ElementType);
            ((IQueryable<T>)mockDbSet).GetEnumerator().Returns(data.GetEnumerator());

            return mockDbSet;
        }
    }
}
