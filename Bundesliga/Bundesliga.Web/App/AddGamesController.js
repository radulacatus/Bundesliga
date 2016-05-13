app.controller('AddGamesController', function ($scope, notifier, playedGames, teams) {
    var vm = this;

    vm.addGameResult = addGameResult;
    vm.teams = teams;
    
    function addGameResult()
    {
        var gameResult = {
            Team1Name: vm.team1.TeamName,
            Team1Goals: vm.team1Goals,
            Team2Goals: vm.team2Goals,
            Team2Name: vm.team2.TeamName,
            Stage: vm.stage
        };

        playedGames.push(gameResult);
    }
});