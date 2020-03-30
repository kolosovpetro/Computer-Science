using System;
using System.IO;

namespace Assignments_6
{
    internal class CaptainsJournal
    {
        private string fileFolder;
        private string fileName;
        private string fileFullPath;

        private void SetFileName()
        {
            fileName = $"{DateTime.Now:dd/MM/yyyy}.txt";
            fileFolder = "../../CaptainsJournal";
            fileFullPath = fileFolder + '/' + fileName;
        }

        public void WriteLog()
        {
            for (string input = Console.ReadLine(); input != null && !input.Equals("start"); input = Console.ReadLine())
            {
                Console.WriteLine("This entry is not going to log. Type start to access to Captain's log.");
            }

            SetFileName();

            Console.WriteLine("Entering Captain's journal ... ");

            if (!Directory.Exists(fileFolder))
            {
                Directory.CreateDirectory(fileFolder);
            }

            using (var sw = new StreamWriter(fileFullPath, true))
            {
                sw.WriteLine("Captain's Log");
                sw.WriteLine($"Star date {fileName} ");

                for (string input = Console.ReadLine(); input != null && !input.Equals("end"); input = Console.ReadLine())
                {
                    sw.WriteLine(input);
                }

                sw.WriteLine("Signature: Jean Luke Picard");
            }
        }
    }
}
