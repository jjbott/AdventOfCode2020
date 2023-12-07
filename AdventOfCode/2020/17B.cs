using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode._2020
{
    class _17B
    {
        public class State
        {
            public int _xs;
            public int _ys;
            public int _zs;
            public int _ws;
            private bool[,,,] _state;
            public State(int xs, int ys, int zs, int ws)
            {
                _xs = xs;
                _ys = ys;
                _zs = zs;
                _ws = ws;
                _state = new bool[xs, ys, zs, ws];
            }

            private (int x, int y, int z, int w) GlobalToLocal(int x, int y, int z, int w)
            {
                // [3,3,3]
                // 0,0,0 = 1,1,1
                // 1,1,1 = 2,2,2
                // -1,-1,-1 = 0,0,0
                return (_xs / 2 + x, _ys / 2 + y, _zs / 2 + z, _ws / 2 + w);
            }

            public (int x, int y, int z, int w) LocalToGlobal(int x, int y, int z, int w)
            {
                // ls = xs/2 + gx
                // -gx = xs/2 -ls
                // gx = ls - xs/2
                return (x - _xs / 2, y - _ys / 2, z - _zs / 2, w - _ws / 2);
            }

            public bool GetCell(int x, int y, int z, int w)
            {
                var c = GlobalToLocal(x, y, z, w);
                
                if (c.x < 0 || c.x >= _xs
                    || c.y < 0 || c.y >= _ys
                    || c.z < 0 || c.z >= _zs
                    || c.w < 0 || c.w >= _ws)
                {
                    return false;
                }

                return _state[c.x, c.y, c.z, c.w];
            }

            public void SetCell(int x, int y, int z, int w, bool value)
            {
                var c = GlobalToLocal(x, y, z, w);
                _state[c.x, c.y, c.z, c.w] = value;
            }

            public bool NextCellState(int x, int y, int z, int w)
            {
                var activeCount = 0;

                for (var zi = z -1; zi <= z + 1; ++zi)
                {
                    for (var yi = y - 1; yi <= y + 1; ++yi)
                    {
                        for (var xi = x - 1; xi <= x + 1; ++xi)
                        {
                            for (var wi = w - 1; wi <= w + 1; ++wi)
                            {
                                if ((xi != x || yi != y || zi != z || wi != w) && GetCell(xi, yi, zi, wi))
                                {
                                    activeCount++;
                                }
                            }
                        }
                    }
                }

                if (GetCell(x, y, z, w))
                {
                    if (activeCount == 2 || activeCount == 3)
                    {
                        return true;
                    }   
                }
                else
                {
                    if ( activeCount == 3)
                    {
                        return true;
                    }
                }

                return false;
            }

            public int ActiveCount()
            {
                return _state.Cast<bool>().Where(x => x).Count();
            }
        }
            
        public void RunB()
        {
            var lines = input.Split("\r\n");

            var current = new State(lines[0].Length, lines.Length, 1, 1);

            for(var y = 0; y < lines.Length; ++y)
            {
                for (var x = 0; x < lines[y].Length; ++x)
                {
                    var g = current.LocalToGlobal(x, y, 0, 0);
                    current.SetCell(g.x, g.y, 0, 0, lines[y][x] == '#');
                }
            }

            for(var i = 0; i < 6; ++i)
            {
                var next = new State(current._xs + 2, current._ys + 2, current._zs + 2, current._ws + 2);

                for (var z = 0; z < next._zs; ++z)
                {
                    for (var y = 0; y < next._ys; ++y)
                    {
                        for (var x = 0; x < next._xs; ++x)
                        {
                            for (var w = 0; w < next._ws; ++w)
                            {
                                var g = next.LocalToGlobal(x, y, z, w);
                                next.SetCell(g.x, g.y, g.z, g.w, current.NextCellState(g.x, g.y, g.z, g.w));
                            }
                        }
                    }
                }

                current = next;
            }

            Console.WriteLine(current.ActiveCount());
        }

        private string input = @"#......#
##.#..#.
#.#.###.
.##.....
.##.#...
##.#....
#####.#.
##.#.###";
    }
}
