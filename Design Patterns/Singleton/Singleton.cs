using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Singleton
    {
        private static Singleton Instance;
        private Singleton() { }
        public static Singleton GetInstance()
        {
            if (Singleton.Instance == null)
                Instance = new Singleton();
            return Instance;
        }
    }
}
