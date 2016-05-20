using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Bundesliga.Api.Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBundesligaService
    {
        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Bare, 
            UriTemplate = "/teams")]
        List<Bundesliga.Api.Contracts.Team> GetAllTeams();

        [OperationContract]
        [WebInvoke(Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat=WebMessageFormat.Json,
            BodyStyle=WebMessageBodyStyle.Bare,
            UriTemplate = "/game")]
        [FaultContract(typeof(InvalidGameFault))]
        Bundesliga.Api.Contracts.Game AddGame(Bundesliga.Api.Contracts.Game game);

        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Bare, 
            UriTemplate = "/games")]
        List<Bundesliga.Api.Contracts.Game> GetAllGames();

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/game/{id}")]
        void RemoveGame(string id);
    }
}
