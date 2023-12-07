using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode._2020
{
    class _13
    {
        public void RunA()
        {
            var lines = input2.Split("\r\n");
            var earliestTime = int.Parse(lines[0]);
            var schedules = lines[1].Split(",").Where(s => s != "x").Select(s => int.Parse(s));

            var x = schedules.Select(s => (s, div: earliestTime / (double)s, wait: Math.Truncate(0.5 + (s * (1 - ( (earliestTime / (double)s) - Math.Truncate(earliestTime / (double)s)))))));
            var minWait = x.Aggregate((curMin, x) => (curMin.wait == default(double) || x.wait < curMin.wait ? x : curMin));

            Console.WriteLine($"{minWait.wait * minWait.s}");
        }

        public void RunB()
        {
            /*
            The earliest timestamp that matches the list 17,x,13,19 is 3417.
            67,7,59,61 first occurs at timestamp 754018.
            67,x,7,59,61 first occurs at timestamp 779210.
            67,7,x,59,61 first occurs at timestamp 1261476.
            1789,37,47,1889 first occurs at timestamp 1202161486.
            */
            // 17x = t
            // 13y = (t+2)
            // 17x +2 = t + 2
            // 17x +2  = 13y
            // (17x + 2)/13 = y

            // t/17 == int
            // (t+2)/13 = int
            // (t + 3)/19 = int
            // 17t = 19t + 3
            // 13t + 2 = 19t + 3
            // 19t - 13t = 2-3
            // 4t = -1

            // 
            // 779
            //var lines = input2.Split("\r\n");
            //var schedules = lines[1].Split(",").Select(s => s == "x" ? (int?)null : int.Parse(s)).ToArray();
            //var schedules = "1789,37,47,1889".Split(",").Select(s => s == "x" ? (int?)null : int.Parse(s)).ToArray();


            // 3,5,7 = 54
            // 3,5 = 9
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            //         *              *              *              *              *              *              *              *
            // ......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
            //                                                      *
            // x,x,7,x,x,x,x,x,15

            // 3,x,5
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            //   *              *              *              *              *              *              *              *

            // x,3,x,5
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            //  *              *              *              *              *              *              *              *

            // 3,x,x,5
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            // 12

            // 3,5 = 9
            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|

            // ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            // ....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            //         *              *              *              *              *              *              *              *

            //var schedules = "67,7,x,59,61".Split(",").Select((s, i) => s == "x" ? (s: -1, p: i) : (s: int.Parse(s), p: i)).Where(s => s.s > 0).OrderBy(s => s.s).AsEnumerable();

            //var schedules = "17,x,13,19".Split(",").Select((s, i) => s == "x" ? (s: -1, p: i) : (s: int.Parse(s), p: i)).Where(s => s.s > 0);

            // ......|......|......|......|......|......|......|......|......|
            // ..........................................................|

            // 3,5,7 = 54
            // 3,5 = 9
            //          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
            //          ..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|..|
            //         x...|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|....|
            //        xx....|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|......|
            //    xxxxxx........|..............|..............|..............|..............|..............|..............|..............|
            //                  *              *              *              *              *              *              *              *


            /*
             * 17,x,13,19 is 3417.
            67,7,59,61 first occurs at timestamp 754018.
            67,x,7,59,61 first occurs at timestamp 779210.
            67,7,x,59,61 first occurs at timestamp 1261476.
            1789,37,47,1889 first occurs at timestamp 1202161486.*/

            //input2 = "\r\n67,7,59,61";
            //input2 = "\r\n67,7,x,59,61";
            //input2 = "\r\n3,5,7";
            var lines = input2.Split("\r\n");
            var schedules = lines[1].Split(",").Select((s, i) => s == "x" ? (s: (Int64)(-1), p: (Int64)i) : (s: Int64.Parse(s), p: (Int64)i)).Where(s => s.s > 0);//.OrderBy(s => s.s).AsEnumerable();
            

            do
            {
                var temp = schedules.Take(2).Select(s => (s: s.s, p: s.p, a: s.s - s.p)).ToArray();
                schedules = schedules.Skip(2);

                var combined = combine(temp[0].s, -temp[0].p, temp[1].s, -temp[1].p);
                schedules = schedules.Append((s: combined.period, combined.period - combined.phase));
                Console.WriteLine(combined.phase);
            }
            while (schedules.Count() > 1);

            return;
            do
            {
                var temp = schedules.Take(2).Select(s => (s: s.s, p: s.p, a: s.s - s.p)).ToArray();
                schedules = schedules.Skip(2);

                do
                {
                    var combined = combine(temp[0].s, temp[0].p, temp[1].s, temp[1].p);
                    schedules = schedules.Append((s: combined.period, combined.phase));
                    Console.WriteLine(combined.phase);
                }
                while (schedules.Count() > 1);

                while (true)
                {
                    var min = Int64.MaxValue;
                    var minIndex = 0;
                    for (var i = 0; i < temp.Length; ++i)
                    {
                        var s = temp[i];
                        if (s.a + s.p < min)
                        {
                            min = s.a + s.p;
                            minIndex = i;
                        }
                    }

                    temp[minIndex].a += temp[minIndex].s;

                    if (temp.Select(s => s.a).Distinct().Count() == 1)
                    {
                        Console.WriteLine(temp[0].a);
                        break;
                    }
                }
                schedules = schedules.Append((s: temp[0].s * temp[1].s, (temp[0].s * temp[1].s)- temp[0].a));

            }
            while (schedules.Count() > 1);
            //while (temp.Where(s => s.HasValue).Distinct().Count() != 1);
            
            int g = 56;

        }

        private (Int64 period, Int64 phase) combine(Int64 a, Int64 a_phase, Int64 b, Int64 b_phase)
        {
            //var diff = a_phase - b_phase;
            var c = combine_phased_rotations(a, (a_phase + a) % a, b, (b_phase + b) % b);
            //c.phase += diff;
            return c;
        }

        private Int64 arrow_alignment(Int64 a, Int64 a_phase, Int64 b, Int64 b_phase)
        {
            var combined = combine_phased_rotations(a, (-a_phase + a) % a, b, (-b_phase + b) % b);
            //var combined = combine_phased_rotations(a, a_phase, b, b_phase);

            return (combined.phase + combined.period) % combined.period;
        }

        private (Int64 period, Int64 phase) combine_phased_rotations(Int64 a_period, Int64 a_phase, Int64 b_period, Int64 b_phase)
        {
            var gcd = ExtendedGcd(a_period, b_period);
            var phase_difference = a_phase - b_phase;
            Int64 pd_remainder;
            Int64 pd_mult = Math.DivRem(phase_difference, gcd.gcd, out pd_remainder);
            var combined_period = checked(a_period / gcd.gcd * b_period);
            BigInteger product = gcd.s;
            product *= pd_mult;
            product *= a_period;
            product = a_phase - product;
            var combined_phase = (Int64)(product % combined_period);
            //var combined_phase = checked((a_phase - gcd.s * pd_mult * a_period ) % combined_period);
            while (combined_phase < 0) { combined_phase += combined_period; }

            return (combined_period, combined_phase);
        }

        private (Int64 gcd, Int64 s, Int64 t) ExtendedGcd(Int64 a, Int64 b)
        {
            var (old_r, r) = (a, b);
            var (old_s, s) = ((Int64)1, (Int64)0);
            var (old_t, t) = ((Int64)0, (Int64)1);

            while (r != 0)
            {
                Int64 remainder;
                var quotient = Math.DivRem(old_r, r, out remainder);
                (old_r, r) = (r, remainder);
                (old_s, s) = (s, old_s - quotient * s);
                (old_t, t) = (t, old_t - quotient * t);
            }

            return (gcd:old_r, s:old_s, t:old_t);
        }

        private string input = @"939
7,13,x,x,59,x,31,19";

        private string input2 = @"1000509
17,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,739,x,29,x,x,x,x,x,x,x,x,x,x,13,x,x,x,x,x,x,x,x,x,23,x,x,x,x,x,x,x,971,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,19";
    }
}
