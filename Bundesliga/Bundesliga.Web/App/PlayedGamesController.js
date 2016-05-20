app.controller('PlayedGamesController', function ($scope, playedGames, bundesligaService) {
    var vm = this;

    vm.nextStage = nextStage;
    vm.previousStage = previousStage;
    vm.remove = remove;

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

    function remove(g) {
        var i = playedGames.indexOf(g);
        if (i > -1) {
            bundesligaService.deleteGame({ id: g.Id }).$promise.then(function () {
                playedGames.splice(i, 1);
                toastr.success("Removed game with id: " + g.Id);
            }, function () {
                toastr.error("Could not remove game with id: " + g.Id);
            });
        }
        else {
            toastr.error("Could not find game with id: " + g.Id);
        }
    }
});