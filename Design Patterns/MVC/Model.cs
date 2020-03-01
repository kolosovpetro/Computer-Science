using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class Model
    {
        Controller Cont;
        public Model(Controller newCont)
        {
            this.Cont = newCont;
        }

        public string GetSetting()
        {
            return this.Cont.GetUserChoose;
        }

    }
}
