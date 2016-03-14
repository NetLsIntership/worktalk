using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WorkTalk.Domain.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public IList<Guid> Messages { get; set; }
    }
}
