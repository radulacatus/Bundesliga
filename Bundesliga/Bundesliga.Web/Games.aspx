<%@ Page Title="" Language="C#" MasterPageFile="~/AngularPage.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="Bundesliga.Web.Games" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" ng-app="app" ng-cloak>
        <div class="row">
            <div class="col-md-12">
                <h2>Fixtures</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5" ng-controller="AddGameController as addGameCtrl">
                <div ng-form="addGameCtrl.addGameForm" ng-class="{submitted: addGameCtrl.addGameForm.submitted}">
                    <h3>Add game: </h3>
                    <div class="form-group">
                        <input type="number" name="stage" class="form-control" placeholder="Stage" ng-model="addGameCtrl.stage" min="1" required />
                        <div ng-messages="addGameCtrl.addGameForm.stage.$error" role="alert" class="text-danger" ng-if="addGameCtrl.addGameForm.submitted">
                            <div ng-message="required">Please enter a value for this field.</div>
                            <div ng-message="number">Plese enter a numeric value.</div>
                            <div ng-message="min">The stage should be a number greater than 0.</div>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="control-label form-vertical-align">Team 1</label>
                        <select class="form-control" name="team1" ng-model="addGameCtrl.team1" ng-options="team as team.TeamName for team in addGameCtrl.teams track by team.Id" required >
                            <option value="">Select a team</option>
                        </select>
                        <div ng-messages="addGameCtrl.addGameForm.team1.$error" role="alert" class="text-danger" ng-if="addGameCtrl.addGameForm.submitted">
                            <div ng-message="required">Please select a team.</div>
                        </div>
                    </div>
                    <div class="form-group">
                        <input type="number" name="team1Goals" class="form-control" placeholder="Goals team 1" ng-model="addGameCtrl.team1Goals" min="0" required />
                        <div ng-messages="addGameCtrl.addGameForm.team1Goals.$error" role="alert" class="text-danger" ng-if="addGameCtrl.addGameForm.submitted">
                            <div ng-message="required">Please enter a value for this field.</div>
                            <div ng-message="number">Plese enter a numeric value.</div>
                            <div ng-message="min">Only positive values are allowed.</div>
                        </div>
                    </div>
                    <br />
                    <div class="form-group clearfix">
                        <label class="control-label form-vertical-align">Team 2</label>
                        <select class="form-control" name="team2" ng-model="addGameCtrl.team2" ng-options="team as team.TeamName for team in addGameCtrl.teams track by team.Id" required >
                            <option value="">Select a team</option>
                        </select>
                        <div ng-messages="addGameCtrl.addGameForm.team2.$error" role="alert" class="text-danger" ng-if="addGameCtrl.addGameForm.submitted">
                            <div ng-message="required">Please select a team.</div>
                        </div>
                    </div>
                    <div class="form-group">
                        <input type="number" name="team2Goals" class="form-control" placeholder="Goals team 2" ng-model="addGameCtrl.team2Goals" min="0" required />
                        <div ng-messages="addGameCtrl.addGameForm.team2Goals.$error" role="alert" class="text-danger" ng-if="addGameCtrl.addGameForm.submitted">
                            <div ng-message="required">Please enter a value for this field.</div>
                            <div ng-message="number">Plese enter a numeric value.</div>
                            <div ng-message="min">Only positive values are allowed.</div>
                        </div>
                    </div>
                    <br />
                    <div class="pull-right">
                        <button type="button" class="btn btn-primary" ng-click="addGameCtrl.addGameResult()" ng-disabled="!addGameCtrl.addGameForm.$valid && addGameCtrl.addGameForm.submitted">Add game result&nbsp;</button>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="well sidebar-nav" ng-controller="GamesListController as gamesListCtrl">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="pager">
                                <li class="previous" ng-click="gamesListCtrl.previousStage()" ng-disabled="gamesListCtrl.stage <= 1"><a href="#">&larr;</a></li>
                                <li>Stage {{gamesListCtrl.stage}} results</li>
                                <li class="next" ng-click="gamesListCtrl.nextStage()"><a href="#">&rarr;</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="list-group">
                        <div class="list-group-item" ng-repeat="game in gamesListCtrl.playedGames | filter: {Stage: gamesListCtrl.stage} ">
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="row">
                                        <div class="col-md-5">{{game.Team1Name}} </div>
                                        <div class="col-md-2"><b>{{game.Team1Goals}} - {{game.Team2Goals}}</b> </div>
                                        <div class="col-md-5">{{game.Team2Name}}</div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <span class="badge" ng-click="gamesListCtrl.remove(game)">X</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
