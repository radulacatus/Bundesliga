using Bundesliga.Api;
using Bundesliga.Api.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Bundesliga.Tests.ApiTests
{
    [TestClass]
    public class BundesligaServiceTests
    {
        public BundesligaService _bundesligaService { get; set; }

        public IBundesligaContextService _bundesligaContextService { get; set; }

        [TestMethod]
        public void GivenAddGameIsCalled_WhenTeam1HasDuplicateGame_ThenFaultExceptionIsThrown()
        {
            var game = new Game{ Stage = 1, Team1Id = 1, Team2Id = 2 };

            AssertThrows(() => _bundesligaService.AddGame(game), typeof(FaultException<InvalidGameFault>));
        }

        [TestMethod]
        public void GivenAddGameIsCalled_WhenTeam1SameAsTeam2_ThenFaultExceptionIsThrown()
        {
            var game = new Game { Stage = 1, Team1Id = 1, Team2Id = 1 };

            AssertThrows(() => _bundesligaService.AddGame(game), typeof(FaultException<InvalidGameFault>));
        }

        [TestMethod]
        public void GivenAddGameIsCalled_WhenInputIsOk_ThenInsertGameIsCalled()
        {
            var game = new Game { Stage = 2, Team1Id = 3, Team2Id = 2 };

            _bundesligaService.AddGame(game);

            _bundesligaContextService.Received(1).InsertGame(game);
        }

        [TestInitialize]
        public void SetUp()
        {
            var gamesStage1 = new List<Game>()
            {
                new Game { Team1Id = 1, Team2Id = 2, Stage = 1 },
                new Game { Team1Id = 4, Team2Id = 3, Stage = 1 },
                new Game { Team1Id = 5, Team2Id = 6, Stage = 1 },
            };

            var gamesStage2 = new List<Game>()
            {
                new Game { Team1Id = 1, Team2Id = 4, Stage = 1 }
            };

            _bundesligaContextService = Substitute.For<IBundesligaContextService>();
            _bundesligaContextService.GetGamesByStage(1).Returns(gamesStage1);
            _bundesligaContextService.GetGamesByStage(2).Returns(gamesStage2);
            _bundesligaService = new BundesligaService(_bundesligaContextService);
        }

        private static void AssertThrows(Action action, Type exceptionType)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, exceptionType);
                return;
            }
            Assert.Fail();
        }
    }
}
