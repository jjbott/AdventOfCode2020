using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _25
    {
        public void RunA()
        {
            //input = "5764801\r\n17807724";
            var pubicKeys = input.Split("\r\n").Select(l => int.Parse(l)).ToList();
            var loopCounts = new int[2] { 0, 0 };

            var subject = 7;
            var value = 1;
            var mod = 20201227;
            for (int i = 0; loopCounts.Any(l => l == 0); ++i)
            {
                value = checked((value * subject) % mod);
                for (var x = 0; x < pubicKeys.Count; ++x)
                {
                    if ( loopCounts[x] == 0 && value == pubicKeys[x])
                    {
                        loopCounts[x] = i + 1;
                    }
                }
            }

            subject = pubicKeys[1];
            value = 1;
            for (int i = 0; i < loopCounts[0]; ++i)
            {
                //Console.WriteLine(value);
                value = checked((int)(((Int64)value * subject) % mod));
            }

            Console.WriteLine(value);
        }

        private string input = @"9717666
20089533";
    }
}
