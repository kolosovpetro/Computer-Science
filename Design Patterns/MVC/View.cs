using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class View
    {
        Model Mod;
        string Message;
        public View(Model newMod)
        {
            this.Mod = newMod;
            if (Mod.GetSetting() == "1")
                this.Message = "We write message 1.";
            else
                this.Message = "Unknown Message";
        }

        public void PrintMessage()
        {
            Console.WriteLine($"Final output: {this.Message}");
        }
    }
}
