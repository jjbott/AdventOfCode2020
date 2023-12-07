using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _10
    {
        public void RunA()
        {
            var data = input.Split("\r\n").Select(l => int.Parse(l)).OrderBy(x => x);
            var counts = new Dictionary<int, int>(){ { 1, 0 }, {2,0}, { 3,0} };

            var previous = 0;
            foreach(var x in data)
            {
                counts[x - previous]++;
                previous = x;
            }

            counts[3]++;
            Console.WriteLine($"{counts[1]} {counts[3]} {counts[1] * counts[3]}");
        }

        public void RunB()
        {
            // (0), 1, 4, 5, 6, 7, 10, 11, 12, 15, 16, 19, (22) == 8

            // 0,1,4 (5,6) 7,10 (11),12
            // 0,1,4(3),5(2),6,7,10(2),11,12,15,16,19,22

            // 0,1(2),3(2),4(2),6,7
            /*
            1,3,4,6
            1,4,6
            1,3,6
            1,

             */

            var data = input.Split("\r\n").Select(l => int.Parse(l)).OrderBy(x => x).Prepend(0).ToArray();
            List<List<int>> choiceGroups = new List<List<int>>();
            List<int> choices = new List<int>();
            for (int i = 0; i < data.Length; ++i)
            {
                var choiceCount = 0;
                for (int j = i + 1; j < data.Length; ++j)
                {
                    if (data[j] - data[i] <= 3)
                    {
                        choiceCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (choiceCount > 1)
                {
                    choices.Add(choiceCount);
                } 
                else
                {
                    if(choices.Any())
                    {
                        choiceGroups.Add(choices);
                        choices = new List<int>();
                    }
                }
            }

            Int64 sln = 1;
            // Dont think the math in the select works in the general case, but it worked for the sln
            // 2 => 1
            // 3,2 => 4
            // 3,3,2 => 7
            // 3,3,3,2 => ???
            foreach(var v in choiceGroups.Select(g => g.Count == 1? 2 : g.Sum()-1))
            {
                sln *= v;
            }

            Console.WriteLine(sln);
        }
        private string input = @"74
153
60
163
112
151
22
67
43
160
193
6
2
16
122
126
32
181
180
139
20
111
66
81
12
56
63
95
90
161
33
134
31
119
53
148
104
91
140
36
144
23
130
178
146
38
133
192
131
3
73
11
62
50
89
98
103
110
164
48
80
179
92
194
86
40
13
123
68
115
19
46
77
152
138
69
49
59
30
132
9
185
1
188
171
72
116
101
61
141
107
21
47
147
182
170
39
37
127
26
102
137
191
162
172
29
10
154
157
83
82
175
145
167";
    }
}
