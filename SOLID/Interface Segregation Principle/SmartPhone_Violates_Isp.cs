using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.ISP
{
    abstract public class SmartPhone
    {
        /// <summary>
        /// Performs call of phone.
        /// </summary>
        public abstract void Call();

        /// <summary>
        /// Makes photo user desires
        /// </summary>
        public abstract void MakePhoto();

        /// <summary>
        /// Uses MP3 function of smartphone in order to listen music
        /// </summary>
        public abstract void ListenMusic();
    }

    abstract public class Phone
    {
        /// <summary>
        /// Implements call method
        /// </summary>
        abstract public void Call();
    }
}
