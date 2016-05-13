using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bundesliga.Tests
{
    [TestClass]
    public class ServiceClientTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var client = new BundesligaService.BundesligaServiceClient())
            {
                var teams = client.GetAllTeams();
                Console.WriteLine(teams.Length);
            }
        }
    }
}
