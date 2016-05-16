<%@ Page Title="" Language="C#" MasterPageFile="~/AngularPage.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="Bundesliga.Web.Games" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" ng-app="app">
        <div class="well">
            <div class="container">
                <h2>Fixtures</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6" ng-controller="AddGamesController as agCtrl">
                <div>
                    <h3>Add games: </h3>
                    <input type="number" class="col-xs-4" placeholder="Stage" ng-model="agCtrl.stage" />
                    <br />
                    <br />
                    <div class="form-group clearfix">
                        <label class="control-label form-vertical-align">Team 1</label>
                        <br />
                        <div class="form-vertical-align">
                            <div class="input-group">
                                <select class="form-control" ng-model="agCtrl.team1" ng-options="team as team.TeamName for team in agCtrl.teams track by team.Id">
                                    <option value=""></option>
                                </select>
                                <span class="input-group-addon pointer"><span class="glyphicon glyphicon-select"></span></span>
                            </div>
                        </div>
                    </div>
                    <input type="number" class="col-xs-4" placeholder="Goals team 1" ng-model="agCtrl.team1Goals" />
                    <br />
                    <br />
                    <div class="form-group clearfix">
                        <label class="control-label form-vertical-align">Team 2</label>
                        <br />
                        <div class="form-vertical-align">
                            <div class="input-group">
                                <select class="form-control" ng-model="agCtrl.team2" ng-options="team as team.TeamName for team in agCtrl.teams track by team.Id">
                                    <option value=""></option>
                                </select>
                                <span class="input-group-addon pointer"><span class="glyphicon glyphicon-select"></span></span>
                            </div>
                        </div>
                    </div>
                    <input type="number" class="col-xs-4" placeholder="Goals team 2" ng-model="agCtrl.team2Goals" />
                    <br />
                    <br />
                </div>
                <div class="pull-left">
                    <button type="button" class="btn btn-primary" ng-click="agCtrl.addGameResult()">Add game result&nbsp;</button>
                </div>
            </div>
            <div class="col-md-6">
                <div class="well sidebar-nav" ng-controller="PlayedGamesController as pgCtrl">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-1">
                        <button type="button" class="btn pull-left btn-sm" ng-click="pgCtrl.previousStage()">&lt;</button>
                        <h4 class="pull-left">Stage {{pgCtrl.stage}} results</h4>
                        <button type="button" class="btn pull-left btn-sm" ng-click="pgCtrl.nextStage()">&gt;</button>
                            </div>
                    </div>
                    <table>
                        <tr class="row" ng-repeat="game in pgCtrl.playedGames | filter: {Stage: pgCtrl.stage} ">
                            <td class="col-md-4">{{game.Team1Name}}</td>
                            <td class="col-md-2"><b>{{game.Team1Goals}} - {{game.Team2Goals}}</b></td>
                            <td class="col-md-4">{{game.Team2Name}}</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
