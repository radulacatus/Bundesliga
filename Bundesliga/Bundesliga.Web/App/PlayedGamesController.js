app.controller('PlayedGamesController', function ($scope, playedGames, bundesligaService) {
    var vm = this;

    vm.nextStage = nextStage;
    vm.previousStage = previousStage;

    bundesligaService.getAllGames().$promise.then(function (response) {
        response.forEach(function (g) {
            playedGames.push(g);
        });

        vm.stage = Math.max.apply(null, playedGames.map(function (x) { return x.Stage }));
        vm.playedGames = playedGames;
    });

    function nextStage() { vm.stage++; }

    function previousStage() {
        if (vm.stage > 1) {
            vm.stage--;
        }
    }
});