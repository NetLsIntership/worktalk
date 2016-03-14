using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTalk.Domain.Excepitons
{
    public class UserIsRegisteredException : Exception
    {
        public UserIsRegisteredException() { }

        public UserIsRegisteredException(string message) : base(message) { }
    }
}
