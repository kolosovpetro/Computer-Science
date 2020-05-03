// TODO: Improve performance.

namespace Exercises.Optimization
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

    public class E1
    {
        public byte[] Run()
        {
            var random = new Random();
            var list = new List<byte>();

            for (var i = 0; i < 1000000000; ++i)
                list.Add((byte)random.Next(1));

            list = new List<byte>(Shift(list.ToArray(), 100));

            if(list[0] == 1)
                list = new List<byte>(Shift(list.ToArray(), 300));

            return list.ToArray();
        }

        public byte[] Shift(byte[] buffer, int count)
        {
            var list = new List<byte>(buffer);
            for (var i = 0; i < count; ++i)
            {
                list.Add(list.First());
                list.RemoveAt(0);
            }

            return list.ToArray();
        }
    }
}
