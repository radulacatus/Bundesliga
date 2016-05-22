app.factory('bundesligaService', function ($resource) {
    var service = $resource('http://localhost:64196/BundesligaService.svc/:apiMethod/:id', { id: "@id" },
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
            },
            deleteGame: {
                method: 'DELETE',
                isArray: false,
                params: { apiMethod: "game" },
            }
        });

    return service;
});