using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _22
    {
        public void RunA()
        {
            var parts = input.Split("\r\n\r\n");
            var player1 = parts[0].Split("\r\n").Skip(1).Select(l => int.Parse(l)).ToList();
            var player2 = parts[1].Split("\r\n").Skip(1).Select(l => int.Parse(l)).ToList();

            while (player1.Any() && player2.Any())
            {
                var p1 = player1.First();
                player1.RemoveAt(0);

                var p2 = player2.First();
                player2.RemoveAt(0);

                if ( p1 > p2 )
                {
                    player1.Add(p1);
                    player1.Add(p2);
                }
                else
                {
                    player2.Add(p2);
                    player2.Add(p1);
                }
            }

            var score = player1.Union(player2).Reverse().Select((e, i) => e * (i + 1)).Sum();

            Console.WriteLine(score);
        }

        class Game
        {
            List<(List<int> p1, List<int> p2)> previousStates = new List<(List<int> p1, List<int> p2)>();
            List<int> _p1;
            List<int> _p2;

            public Game(List<int> p1, List<int> p2)
            {
                _p1 = p1;
                _p2 = p2;
            }

            public bool Run()
            {
                while (_p1.Any() && _p2.Any())
                {
                    if (previousStates.Any(s => _p1.SequenceEqual(s.p1) && _p2.SequenceEqual(s.p2)))
                    {
                        return true; // p1 win
                    }

                    previousStates.Add((new List<int>(_p1), new List<int>(_p2)));

                    var p1 = _p1.First();
                    _p1.RemoveAt(0);

                    var p2 = _p2.First();
                    _p2.RemoveAt(0);

                    if (p1 <= _p1.Count() && p2 <= _p2.Count())
                    {
                        if (new Game(new List<int>(_p1.Take(p1)), new List<int>(_p2.Take(p2))).Run())
                        {
                            // p1 won
                            _p1.Add(p1);
                            _p1.Add(p2);
                        }
                        else
                        {
                            _p2.Add(p2);
                            _p2.Add(p1);
                        }
                    }
                    else
                    {
                        if (p1 > p2)
                        {
                            _p1.Add(p1);
                            _p1.Add(p2);
                        }
                        else
                        {
                            _p2.Add(p2);
                            _p2.Add(p1);
                        }
                    }
                }

                return _p1.Any();

            }
        }

        public void RunB()
        {
            //input = testcase1;

            var parts = input.Split("\r\n\r\n");
            var player1 = parts[0].Split("\r\n").Skip(1).Select(l => int.Parse(l)).ToList();
            var player2 = parts[1].Split("\r\n").Skip(1).Select(l => int.Parse(l)).ToList();

            var game = new Game(player1, player2);
            game.Run();

            var score = player1.Union(player2).Reverse().Select((e, i) => e * (i + 1)).Sum();

            Console.WriteLine(score);
        }

        public string testcase1 = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";

        public string input = @"Player 1:
40
26
44
14
3
17
36
43
47
38
39
41
23
28
49
27
18
2
13
32
29
11
25
24
35

Player 2:
19
15
48
37
6
34
8
50
22
46
20
21
10
1
33
30
4
5
7
31
12
9
45
42
16";
    }
}
