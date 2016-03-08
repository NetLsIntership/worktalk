using System;
using System.Collections.Generic;

namespace WorkTalk.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public IList<Guid> Messages { get; set; }
    }
}
