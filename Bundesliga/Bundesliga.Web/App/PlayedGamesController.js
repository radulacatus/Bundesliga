app.controller('PlayedGamesController', function ($scope, notifier, playedGames) {
    var vm = this;

    vm.stage = Math.max.apply(null, playedGames.map(function (x) { return x.Stage }));
    vm.playedGames = playedGames;
    vm.nextStage = nextStage;
    vm.previousStage = previousStage;

    function nextStage() { vm.stage++; }

    function previousStage() {
        if (vm.stage > 1) {
            vm.stage--;
        }
    }
});