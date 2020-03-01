using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class Controller
    {
        string UserChoose;
        public Controller(string newUserChoose)
        {
            this.UserChoose = newUserChoose;
        }

        public string GetUserChoose
        {
            get
            {
                return this.UserChoose;
            }
        }
    }
}
