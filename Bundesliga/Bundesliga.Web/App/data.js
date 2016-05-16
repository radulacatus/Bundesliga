app.value('playedGames', []);

app.factory('bundesligaService', function ($resource) {
    var service = $resource('http://localhost:64196/BundesligaService.svc/:apiMethod', {},
        {
            getAllTeams: {
                method: 'GET',
                isArray: true,
                params: { apiMethod: "teams" }
            },
            addGame: {
                method: 'POST',
                isArray: false,
                params: { apiMethod: "game" },
            },
            getAllGames: {
                method: 'GET',
                isArray: true,
                params: { apiMethod: "games" }
            }
        });

    return service;
});