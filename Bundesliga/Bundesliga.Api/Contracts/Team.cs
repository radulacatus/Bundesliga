using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bundesliga.Api.Contracts
{
    [DataContract]
    public class Team
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TeamName { get; set; }
    }
}