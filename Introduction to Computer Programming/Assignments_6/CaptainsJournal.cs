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
        private readonly string filePath;
        private string fileName;

        public CaptainsJournal()
        {
            this.filePath = $"../../CaptainsJournal/{fileName}.txt";
        }

        private void setFileName()
        {
            this.fileName = $"<{DateTime.Now.Date.ToString()}>";
        }

        public void WriteLog()
        {
            for (string input = Console.ReadLine(); !input.Equals("start"); input = Console.ReadLine())
            {
                Console.WriteLine("This entry is not going to log. Type start to access to Captain's log.");
            }

            this.setFileName();

            Console.WriteLine("Entering Captain's journal ... ");

            using (StreamWriter sw = File.AppendText(filePath + fileName))
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
