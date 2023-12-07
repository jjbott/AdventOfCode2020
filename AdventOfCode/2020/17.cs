using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode._2020
{
    class _17
    {
        public class State
        {
            public int _xs;
            public int _ys;
            public int _zs;
            private bool[,,] _state;
            public State(int xs, int ys, int zs)
            {
                _xs = xs;
                _ys = ys;
                _zs = zs;
                _state = new bool[xs, ys, zs];
            }

            private (int x, int y, int z) GlobalToLocal(int x, int y, int z)
            {
                // [3,3,3]
                // 0,0,0 = 1,1,1
                // 1,1,1 = 2,2,2
                // -1,-1,-1 = 0,0,0
                return (_xs / 2 + x, _ys / 2 + y, _zs / 2 + z);
            }

            public (int x, int y, int z) LocalToGlobal(int x, int y, int z)
            {
                // ls = xs/2 + gx
                // -gx = xs/2 -ls
                // gx = ls - xs/2
                return (x - _xs / 2, y - _ys / 2, z - _zs / 2);
            }

            public bool GetCell(int x, int y, int z)
            {
                var c = GlobalToLocal(x, y, z);
                
                if (c.x < 0 || c.x >= _xs
                    || c.y < 0 || c.y >= _ys
                    || c.z < 0 || c.z >= _zs)
                {
                    return false;
                }

                return _state[c.x, c.y, c.z];
            }

            public void SetCell(int x, int y, int z, bool value)
            {
                var c = GlobalToLocal(x, y, z);
                _state[c.x, c.y, c.z] = value;
            }

            public bool NextCellState(int x, int y, int z)
            {
                var activeCount = 0;

                for (var zi = z -1; zi <= z + 1; ++zi)
                {
                    for (var yi = y - 1; yi <= y + 1; ++yi)
                    {
                        for (var xi = x - 1; xi <= x + 1; ++xi)
                        {
                            if ( (xi != x || yi != y || zi != z) && GetCell(xi, yi, zi))
                            {
                                activeCount++;
                            }
                        }
                    }
                }

                if (GetCell(x, y, z))
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
            
        public void RunA()
        {
            var lines = input.Split("\r\n");

            var current = new State(lines[0].Length, lines.Length, 1);

            for(var y = 0; y < lines.Length; ++y)
            {
                for (var x = 0; x < lines[y].Length; ++x)
                {
                    var g = current.LocalToGlobal(x, y, 0);
                    current.SetCell(g.x, g.y, 0, lines[y][x] == '#');
                }
            }

            for(var i = 0; i < 6; ++i)
            {
                var next = new State(current._xs + 2, current._ys + 2, current._zs + 2);

                for (var z = 0; z < next._zs; ++z)
                {
                    for (var y = 0; y < next._ys; ++y)
                    {
                        for (var x = 0; x < next._xs; ++x)
                        {
                            var g = next.LocalToGlobal(x, y, z);
                            next.SetCell(g.x, g.y, g.z, current.NextCellState(g.x, g.y, g.z));
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
