using System;
using System.Runtime.Serialization;

namespace Bundesliga.Api.Contracts
{
    [DataContract]
    public class InvalidGameFault
    {
        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public Exception InnerException { get; set; }
    }
}
