using ActiveRecordPattern.CopyListRecordEntity;
using ActiveRecordPattern.MovieRecordEntity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mov = MovieRecord.GetMovieById(10);
            Console.WriteLine(mov.ToString());

            CopyListRecord copies = new CopyListRecord(10);

            foreach (var item in copies.Copies)
            {
                Console.WriteLine(item);
            }

        }
    }
}
