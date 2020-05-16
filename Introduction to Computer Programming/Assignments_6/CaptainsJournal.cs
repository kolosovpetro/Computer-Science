using System;
using System.IO;

namespace Assignments_6
{
    internal class CaptainsJournal
    {
        private string _fileFolder;
        private string _fileName;
        private string _fileFullPath;

        private void SetFileName()
        {
            _fileName = $"{DateTime.Now:dd/MM/yyyy}.txt";
            _fileFolder = "../../CaptainsJournal";
            _fileFullPath = _fileFolder + '/' + _fileName;
        }

        public void WriteLog()
        {
            for (var input = Console.ReadLine(); input != null && !input.Equals("start"); input = Console.ReadLine())
            {
                Console.WriteLine("This entry is not going to log. Type start to access to Captain's log.");
            }

            SetFileName();

            Console.WriteLine("Entering Captain's journal ... ");

            if (!Directory.Exists(_fileFolder))
            {
                Directory.CreateDirectory(_fileFolder);
            }

            using (var sw = new StreamWriter(_fileFullPath, true))
            {
                sw.WriteLine("Captain's Log");
                sw.WriteLine($"Star date {_fileName} ");

                for (string input = Console.ReadLine(); input != null && !input.Equals("end"); input = Console.ReadLine())
                {
                    sw.WriteLine(input);
                }

                sw.WriteLine("Signature: Jean Luke Picard");
            }
        }
    }
}
