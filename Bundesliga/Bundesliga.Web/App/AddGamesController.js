app.controller('AddGamesController', function ($scope, toastr, playedGames, bundesligaService) {
    var vm = this;

    vm.addGameResult = addGameResult;
    bundesligaService.getAllTeams().$promise.then(function (result) { vm.teams = result; });
    
    
    function addGameResult()
    {
        var gameResult = {
            Team1Id: vm.team1.Id,
            Team1Name: vm.team1.TeamName,
            Team1Goals: vm.team1Goals,
            Team2Goals: vm.team2Goals,
            Team2Id: vm.team2.Id,
            Team2Name: vm.team2.TeamName,
            Stage: vm.stage
        };

        bundesligaService.addGame(gameResult).$promise.then(
            function (g) {
                playedGames.push(gameResult);
                toastr.success("Added game with id: " + g.Id);
            }, function (e) {
                toastr.error("Error adding game!");
            });
    }
});