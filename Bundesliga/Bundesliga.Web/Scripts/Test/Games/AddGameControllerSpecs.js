describe("Add Game Controller", function () {
    var $controller, $httpBackend, addGameCtrl, toastr, playedGames;
    var teamsResponse = [{ "Id": 1, "TeamName": "Bayer Leverkusen" }, { "Id": 2, "TeamName": "Borussia Dortmund" }];
    var gameResponse = { "Id": 71, "Stage": 1, "Team1Goals": 2, "Team1Id": 2, "Team1Name": "Borussia Dortmund", "Team2Goals": 1, "Team2Id": 1, "Team2Name": "Bayer Leverkusen" };

    beforeEach(module('app'));

    beforeEach(function () {
        module(function ($provide) {
            $provide.constant('toastr', {
                success: jasmine.createSpy('success'),
                warning: jasmine.createSpy('warning'),
                error: jasmine.createSpy('error')
            });
        });
    });

    beforeEach(inject(function ($injector) {
        $controller = $injector.get('$controller');
        $httpBackend = $injector.get('$httpBackend');
        toastr = $injector.get('toastr');
        playedGames = $injector.get('playedGames');

        $httpBackend.expectGET(/\.*\/BundesligaService.svc\/teams/).respond(200, teamsResponse);

        addGameCtrl = $controller('AddGameController');

        $httpBackend.flush();
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    describe("Add New Game", function () {
        describe("When controller is initialized", function () {
            it("A request should be made to get the teams from server", function () {
                expect(addGameCtrl.teams.length).toBe(2);
                expect(addGameCtrl.teams[0].Id).toBe(1);
                expect(addGameCtrl.teams[1].Id).toBe(2);
            });
        });
        describe("When form is invalid", function () {
            it("No request should be made, and form should be marked as submitted", function () {
                addGameCtrl.addGameForm = { $valid: false };

                expect(addGameCtrl.addGameForm.submitted).toBeFalsy();
                addGameCtrl.addGameResult();
                expect(addGameCtrl.addGameForm.submitted).toBe(true);
            });
        });
        describe("When form is valid", function () {
            beforeEach(function () {
                addGameCtrl.team1 = { Id: addGameCtrl.teams[1].Id, TeamName: addGameCtrl.teams[1].TeamName };
                addGameCtrl.team1Goals = 1;
                addGameCtrl.team2Goals = 2;
                addGameCtrl.team2 = { Id: addGameCtrl.teams[0].Id, TeamName: addGameCtrl.teams[0].TeamName };
                addGameCtrl.stage = 1;

                addGameCtrl.addGameForm = { $valid: true };
            });
            it("A request should be made to the server and if successful new game should be added to playedGames", function () {                

                $httpBackend.expectPOST(/\.*\/BundesligaService.svc\/game/).respond(200, gameResponse);
                addGameCtrl.addGameResult();
                $httpBackend.flush();

                expect(playedGames.length).toBe(1);
                expect(addGameCtrl.addGameForm.submitted).toBe(false);
                expect(toastr.success).toHaveBeenCalled();
            });
            it("On server failure an error message should be shown", function () {

                $httpBackend.expectPOST(/\.*\/BundesligaService.svc\/game/).respond(500, { Message: "Internal server error!"});
                addGameCtrl.addGameResult();
                $httpBackend.flush();

                expect(playedGames.length).toBe(1);
                expect(toastr.error).toHaveBeenCalled();
            });
        });
    });
});