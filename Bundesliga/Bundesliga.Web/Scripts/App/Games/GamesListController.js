angular.module('app').controller('GamesListController', function (toastr, playedGames, bundesligaService) {
    var vm = this;

    vm.nextStage = nextStage;
    vm.previousStage = previousStage;
    vm.remove = remove;
    vm.stage;

    activate();

    function activate() {
        bundesligaService.getAllGames().$promise.then(function success(games) {
            games.forEach(function (game) {
                playedGames.push(game);
            });
                        
            vm.playedGames = playedGames;
            setCurrentStage();
        }, function error(data) {
            toastr.error("Could not fetch games from server.");
        });
    }

    function nextStage() {
        vm.stage++;
    }

    function previousStage() {
        if (vm.stage > 1) {
            vm.stage--;
        }
    }

    function remove(game) {
        var index = vm.playedGames.indexOf(game);
        if (index !== -1) {
            bundesligaService.deleteGame({ id: game.Id }).$promise.then(function success() {
                vm.playedGames.splice(index, 1);
                setCurrentStage();
                toastr.success("Removed game with id: " + game.Id);
            }, function error(data) {
                toastr.error("Could not remove game with id: " + game.Id);
            });
        }
        else {
            toastr.error("Could not find game with id: " + game.Id);
        }
    }

    function setCurrentStage() {
        vm.stage = Math.max.apply(null, vm.playedGames.map(function (game) { return game.Stage }));
    }
});