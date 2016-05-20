<%@ Page Title="" Language="C#" MasterPageFile="~/AngularPage.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="Bundesliga.Web.Games" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" ng-app="app">
        <div class="row">
            <div class="col-md-12">
                <h2>Fixtures</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5" ng-controller="AddGamesController as agCtrl">
                <div>
                    <h3>Add game: </h3>
                    <div class="form-group">
                        <input type="number" class="form-control" placeholder="Stage" ng-model="agCtrl.stage" min="1"/>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="control-label form-vertical-align">Team 1</label>
                                <select class="form-control" ng-model="agCtrl.team1" ng-options="team as team.TeamName for team in agCtrl.teams track by team.Id">
                                    <option value=""></option>
                                </select>
                    </div>
                    <div class="form-group">
                        <input type="number"  class="form-control" placeholder="Goals team 1" ng-model="agCtrl.team1Goals" min="0" value="0" text="0" />
                    </div>
                    <br />
                    <div class="form-group clearfix">
                        <label class="control-label form-vertical-align">Team 2</label>
                                <select class="form-control" ng-model="agCtrl.team2" ng-options="team as team.TeamName for team in agCtrl.teams track by team.Id">
                                    <option value=""></option>
                                </select>
                    </div>
                    <div class="form-group">
                        <input type="number" class="form-control"  placeholder="Goals team 2" ng-model="agCtrl.team2Goals" min="0" value="0" />
                        </div>
                    <br />
                </div>
                <div class="pull-right">
                    <button type="button" class="btn btn-primary" ng-click="agCtrl.addGameResult()">Add game result&nbsp;</button>
                </div>
            </div>
            <div class="col-md-7">
                <div class="well sidebar-nav" ng-controller="PlayedGamesController as pgCtrl">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="pager">
                                <li class="previous" ng-click="pgCtrl.previousStage()"><a href="#">&larr;</a></li>
                                <li>Stage {{pgCtrl.stage}} results</li>
                                <li class="next" ng-click="pgCtrl.nextStage()"><a href="#">&rarr;</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="list-group">
                        <div class="list-group-item" ng-repeat="game in pgCtrl.playedGames | filter: {Stage: pgCtrl.stage} ">
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="row">
                                        <div class="col-md-5">{{game.Team1Name}} </div>
                                        <div class="col-md-2"><b>{{game.Team1Goals}} - {{game.Team2Goals}}</b> </div>
                                        <div class="col-md-5">{{game.Team2Name}}</div>
                                    </div>
                                </div>
                            <div class="col-md-2">
                                <span class="badge" ng-click="pgCtrl.remove(game)">X</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </div>
</asp:Content>
