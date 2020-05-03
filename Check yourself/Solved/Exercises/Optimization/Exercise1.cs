// TODO: Improve performance.

namespace Exercises.Optimization
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

    public class E1
    {
        // where possible, use array instead of lists (+ performance)
        // use explicit type instead of dynamic (+ performance)

        public byte[] Run()
        {
            Random random = new Random();
            byte[] byteArray = new byte[1000000000];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)random.Next(1);
            }

            byteArray = Shift(byteArray, 100);

            if(byteArray[0] == 1)
                byteArray = Shift(byteArray, 300);

            return byteArray;
        }

        // shift to the right
        // may be solved by linq, but it could influent on performance

        public byte[] Shift(byte[] buffer, int count)
        {
            int newSize = buffer.Length - count;
            byte[] newByteArray = new byte[newSize];

            newByteArray = Shift(buffer, count);        // be careful with count, may cause out of range exception
                                                        // we don't added try since it influences on perforamnce
            return newByteArray;
        }
    }
}
