using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{
    
        public delegate void MsgHandler<T>(T message) where T : Msg;

        /// <summary>
        /// Base class for all messages that can be sent to objects and components.
        /// </summary>
        public abstract class Msg { }
    
}
