app.controller('AddGameController', function ($scope, toastr, playedGames, bundesligaService) {
    var vm = this;

    vm.addGameResult = addGameResult;
    vm.teams = [];
    vm.addGameForm = null;

    activate();

    function activate() {
        //get teams from db
        bundesligaService.getAllTeams().$promise.then(function success(result) {
            vm.teams = result;
        }, function error(data) {
            toastr.error("No teams found in the database!");
        });
    }

    function addGameResult() {
        if (!vm.addGameForm.$valid) {
            vm.addGameForm.submitted = true;
            return;
        }

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
        function success(game) {
            playedGames.push(game);
            resetForm();
            toastr.success("Added game with id: " + game.Id);
        }, function error(data) {
            toastr.error("Error adding game!");
        });
    }

    function resetForm() {
        vm.addGameForm.submitted = false;
        vm.team1 = null;
        vm.team2 = null;
        vm.team1Goals = null;
        vm.team2Goals = null;        
    }
});