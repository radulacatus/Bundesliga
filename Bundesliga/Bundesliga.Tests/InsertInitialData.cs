using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bundesliga.DataAccess;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Bundesliga.Tests
{
    [TestClass]
    /// WARNING!!! BAD CODE!!
    public class InsertInitialData
    {
        private static string Separator = "#";

        [TestMethod]
        /// This test is used to initialize the database.
        /// If you want to cleanup all data and reinsert initial values
        /// uncomment Ignore attribute and run the test
        [Ignore]
        public void Run()
        {
            using (var ctx = new BundesligaContext())
            {
                ClearDatabase(ctx);

                var file = new System.IO.StreamReader("Resources//Data.txt");

                InsertTeams(ctx, file);

                InsertGames(ctx, file);
                
                file.Close();
            }
        }

        private void InsertGames(BundesligaContext ctx, StreamReader file)
        {
            string line;
            int stage = 0;
            DateTime date = new DateTime();
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length == 1)
                {
                    stage = int.Parse(line);
                    continue;
                }

                if (line.StartsWith("["))
                {
                    line = line.Substring(4, 5);
                    var dateItems = line.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    date = new DateTime(2015, dateItems[1], dateItems[0]);
                    continue;
                }

                var items = line.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var team1Name = items[1];
                var team2Name = items[4];
                var team1 = ctx.Teams.Single(x => x.TeamName == team1Name);
                var team1Goals = int.Parse(items[2]);
                var team2Goals = int.Parse(items[3]);
                var team2 = ctx.Teams.Single(x => x.TeamName == team2Name);
                var game = new Game
                {
                    Date = date,
                    Stage = stage,
                    Team1Id = team1.Id,
                    Team2Id = team2.Id,
                    Team1Goals = team1Goals,
                    Team2Goals = team2Goals
                };
                ctx.Games.Add(game);
            }
            ctx.SaveChanges();
        }

        private static void InsertTeams(BundesligaContext ctx, StreamReader file)
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (line == Separator)
                {
                    break;
                }
                ctx.Teams.Add(new Team { TeamName = line });
            }
            ctx.SaveChanges();
        }

        private static void ClearDatabase(BundesligaContext ctx)
        {
            var allGames = ctx.Games.ToList();
            allGames.ForEach(x => ctx.Games.Remove(x));
            ctx.SaveChanges();

            var allTeams = ctx.Teams.ToList();
            allTeams.ForEach(x => ctx.Teams.Remove(x));
            ctx.SaveChanges();

            ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Games]', RESEED, 0);");
            ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Teams]', RESEED, 0);");
        }
    }
}
