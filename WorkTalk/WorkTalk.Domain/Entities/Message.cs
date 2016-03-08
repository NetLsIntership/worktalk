using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTalk.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }
        public string Text { get; set; }
    }
}
