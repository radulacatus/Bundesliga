var gamesList = element.all(by.repeater('game in gamesListCtrl.playedGames'));
var addGameBtn = $('[ng-click="addGameCtrl.addGameResult()"]');
var removeBtns = $$('[ng-click="gamesListCtrl.remove(game)"]');

describe('Games Page', function () {
    it('should add a game', function () {
        browser.get('http://localhost:5001/Games');

        element(by.model('addGameCtrl.stage')).sendKeys('8');
        element(by.model('addGameCtrl.team1')).$('[value="2"]').click();
        element(by.model('addGameCtrl.team1Goals')).sendKeys('2');
        element(by.model('addGameCtrl.team2')).$('[value="3"]').click();
        element(by.model('addGameCtrl.team2Goals')).sendKeys('1');
        
        expect(gamesList.count()).toEqual(2);

        addGameBtn.click()

        expect(gamesList.count()).toEqual(3);
        expect(gamesList.last().element(by.binding('game.Team1Name')).getText()).toEqual('Borussia Dortmund');
        expect(gamesList.last().element(by.binding('game.Team2Name')).getText()).toEqual('VfL Wolfsburg');

        removeBtns.last().click();
        expect(gamesList.count()).toEqual(2);
    });
});