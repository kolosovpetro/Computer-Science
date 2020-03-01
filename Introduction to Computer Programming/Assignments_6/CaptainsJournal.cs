using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_6
{
    class CaptainsJournal
    {
        private string fileFolder;
        private string fileName;
        private string fileFullPath;

        private void setFileName()
        {
            this.fileName = $"{DateTime.Now.ToString("dd/MM/yyyy")}.txt";
            this.fileFolder = "../../CaptainsJournal";
            this.fileFullPath = fileFolder + '/' + fileName;
        }

        public void WriteLog()
        {
            for (string input = Console.ReadLine(); !input.Equals("start"); input = Console.ReadLine())
            {
                Console.WriteLine("This entry is not going to log. Type start to access to Captain's log.");
            }

            this.setFileName();

            Console.WriteLine("Entering Captain's journal ... ");

            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }

            using (StreamWriter sw = new StreamWriter(fileFullPath))
            {
                sw.WriteLine("Captain's Log");
                sw.WriteLine($"Stardate{fileName}");

                for (string input = Console.ReadLine(); !input.Equals("end"); input = Console.ReadLine())
                {
                    sw.WriteLine(input);
                }

                sw.WriteLine("Signature: Jean Luke Picard");
            }
        }
    }
}
