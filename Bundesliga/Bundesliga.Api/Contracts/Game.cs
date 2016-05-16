using System.Runtime.Serialization;

namespace Bundesliga.Api.Contracts
{
    [DataContract]
    public partial class Game
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Team1Id { get; set; }

        [DataMember]
        public int Team2Id { get; set; }

        [DataMember]
        public int Team1Goals { get; set; }

        [DataMember]
        public int Team2Goals { get; set; }

        [DataMember]
        public int Stage { get; set; }

        [DataMember]
        public string Team1Name { get; set; }

        [DataMember]
        public string Team2Name { get; set; }
    }
}
