﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2020
{
    class _3a
    {
        public void Run()
        {
            var lines = data.Split("\r\n");
            var dx = 3;
            var dy = 1;
            var x = 0;
            var y = 0;
            var width = lines[0].Length;

            var count = 0;

            while ( (y+dy) < lines.Length)
            {
                x += dx;
                y += dy;

                if (lines[y][x % width] == '#') count++;
            }

            Console.WriteLine(count);
        }

        private string data = @"..#......###....#...##..#.#....
.#.#.....#.##.....###...##...##
..#.#..#...........#.#..#......
..#......#..........###........
...#..###..##.#..#.......##..##
......#.#.##...#...#....###....
..........##.....##..##......#.
......#...........#............
#....#..........#..............
.#........##.............###.##
....#.........#.......#.#....##
#.#..#..#..#.......#...#....##.
.#........#......#.##.......#..
..#.....#####.....#....#..#..##
.......#..##.......#......#.###
..#.#...#......#.##...#........
##...................#...##..#.
......#...#.##...##.#......#..#
.#.................#..##...#...
...#.....#.......##.....#.#....
.......#.#......#.....#..#..##.
..........#........#...........
..#.#..........................
.#.##..#.#...#...#.........#...
.....#....#.....#..#.....#.....
...#.#.#.....#.#..#.......#..#.
.....#...###...##...#......##..
#.###......#.#...#.#.#..###....
#.....#..##......#..........#.#
#...............#........#.#..#
.....#..#.........#......##.#..
.....#.##.##..#..##............
...#......##...............#.#.
.#..#.#............##.#........
#.....#..###.............##.#..
...##..#.#..#...........#..#...
#....#.........#.#.............
##.#.........#..###......#.#..#
...#...#......#.#.#.##..#.##...
.....##............#.##.##..#..
....#................#.##..#..#
...#..#.......#...#..#........#
....#...#...#................#.
....##...............#.#...#...
.#.....###...#.......#.##......
....######.#..............###.#
.#..#.........##...............
................##.#..#....###.
.......#............#.#..#..#..
......#.#...............##.#...
...#..####.#...#..#..#......#..
....#.#...#.....#.........#..##
.##..#...#......##....##.#.#...
.##.#.........##...#....#......
..#.#..#...#.#..#.......#...#.#
.........#..#.....##..#........
..#......#..##.....#..#...###..
..#...#....#.#..#..#.#.#..#.#..
...#..#####.....#......#.......
#.#............#......#..#...#.
.........#..........###.......#
......#....#..#.##.#......#..#.
...........##.#....#.#..#......
..#...................#..#.#...
#....##.............##....#...#
##..#....#.........#..........#
....#.#.#...#..#........#.##..#
...............#...#..##..#....
.##.......#.......#...........#
#.........................##...
#........#.#..#..##..####.#....
...................##.....###..
.#.......#..#......#......#...#
..#.........#...#..........#...
..........#......#....#........
.#......#..#...#..#...##....##.
...#.#..#..#......#.....##.####
.......#.#....#.......#........
#...#.#...##..##.#......#......
.#.........#...................
...#..........#.#......#.......
...#.....##....#..........#....
.#..........##..#..#..##....#.#
.##.#..........#...#.##.......#
#...###....#..#.#...#..#.......
..................##...........
..#...##.#...........#....#.##.
..#......#..##..#....##..#...#.
..#....#.....#.##..#.......#..#
#...#....#..#.#....#......##...
.......##..#..........#........
..#.............##.#.....#...#.
...............#....#...#...##.
##...........#.......#.##......
#..#...........#.........#.....
....###.............###.##..##.
.........#.#.....###.......#...
..#.##....#.#..........#....#..
#........#....##...#..#........
......#..........###..#.#......
.....#.#......##.....#..##...#.
.#.......#......#...#...#...#.#
.#..........##.......#.....##.#
###.#...#....#.....#...#......#
..#.#.#..#.##.#..#.............
.....#.........................
.#..###..#...#...#..#..#...#.#.
#................##...##.##....
......#...#...#..........#...#.
..........#.....##.............
..#.#......#........#.......#..
........##.............#.......
.......#......#.##.#..#........
#.#.#....#........#..........#.
##..##......#..#..#.....#.#..##
##..#..........#...............
#.....##...#.#......#.......#.#
#.....#...#....#..#.....##.....
##..........#.#.....#....#...##
..##.###..#.....#.......#...#..
.#.#.......#......###........#.
.#..............#.#..###.......
.#....#..##.........#..#.#.....
....#....#.#....#..#.......##.#
#.......#.......#.........#....
...#....#....#.....##..#..#.#.#
........#....#...........#.....
.#......##.#.#.##..............
#..#.#.....##........#........#
##...#.#.......##.......#...#..
#...#.....#.##...##.#.....#....
....#..##...#........#.#...#...
...#....#.#.#..###...##.#.....#
......#..#.....#..#........##..
.......#.....#.#.........#.#..#
..#.......#.#.#.#.#....#.##...#
.#...#........#..##..#......#..
.#..#............#...#..#.#....
...##......#......#............
..#...#.#.....#.....#..##.#....
.#......#.#......#..#.#........
..#..........##...#.#.....#..#.
#...#.....#..#...#.............
..##.................#....#....
.#....#.......#..##....#......#
.#....###............##....##.#
##..#........#..#...#.......#..
.....#.....#.#.#.##.........#..
.......#..#....#...#...#.......
...#...#...#.#.#..#.#.....#....
#.#........#..#.##..#..###.....
..................#..#.........
#.#.....#..##.........#.......#
###..#.......#..............#..
......#..#.....###..........#..
....#.#...#..#...........#.#...
...#.....#.......#.....#.#.....
#.....##..#......##...........#
#...###...........##..#...#.##.
......##.##.#...#..#....#......
...#.#......##.#......##....#.#
..............#.#.###.......#..
........#....#.......##..#..###
...#.....##.#....#......##..#.#
..##........#.....#.#..#...#...
.#..#.##.........#.....#...#..#
..#..#....#...........#........
.#...#....................#....
##.....##....#.............#.#.
....#.#..#.#..#.#.#..........##
.............##.#.....#..#..#..
.#....#.....##...#.###.........
..#........#........#.#..###...
.##....#...#...#.......#...#.#.
..#...#...#..##........#..#....
..##.#..#..#.....#......#.#..#.
.#........#..#....#..#.........
..#.#.....#.##..#........###.#.
.....#.##.....##.#.............
#.........#.......#...##...#...
..#.##.#..#..#............#....
.##....#..#............#.....#.
###........##.....##.#...#.....
#......##..##.#.#.#.#.#.#..##..
.....###.....#....#......#....#
........#.........##...#....#.#
.#.#.....#.#..#..##......#...#.
...#.##....#..#.###..#..##.....
....#..........##..#..#..#..#..
...#..#.##..#..#....#.........#
.....#..###.#.....#.....#..#...
......#...#....#.##...#.#......
.#.###..##.....##.##......##...
.....#.#...........#.#.........
#........#...#..#......##.#....
..#.......##....##....#.##.#..#
...###.#.........#......#.....#
..#.##..#....#.....##...#.##...
....##.##.............#...#....
##..#...#..#..#..#.............
.....#.....#.....#.............
...#.##.......#..#.#.....#....#
#.....##.........#......##.....
.....##..........#..#...#..#...
#...###....#.......#...##......
.#....#..#......#.....#...#.#..
#........#.#.#...#.....###.#.##
##...#...##..#..#....#.........
....#............#..#.....#....
#......#.........##....#.......
.#..#..#........#.............#
.##..........#......#.......#..
#............#..#....#.........
....#.#.....#.##...#.....#.#...
...#.#..#...##..#...#.#.#......
#....#..#.........##..#.#.#..##
.#...#..............#.......#..
#...#.....#.#........##......##
...#....##.####.#.........#.#.#
....###.#..#............#.#..#.
....#......#...#......##.#.#.#.
.....#..#.#.##.#...##..........
##..#...#.#...###.............#
....#...#..#.....#.#..#..#..#..
#..........####......#.....###.
.........#........#.##.#...#...
.........#..........#.#..###...
.....##........##.........#...#
..##....#...#.......##.........
.....#.#......##....#...#...#..
.##..#..##.....................
.......#...#..#..#...##....#...
.#...#.......###...#..#..#.....
.......#.....##.##.#.......#..#
.##......#...#....#..#......##.
.##....#..#....#...#...#.......
.........##..#..#.#.#.....##...
...#..............#..#.....####
.#.#.#..#.......#.......#......
..#.#......#..........#........
.#...#.#..#.......#..#..#..#...
.......##.#...#..#....#.....#..
.##...##....##...#........####.
....#.#..##....#...#....#.#....
.....#.....#..#..#.#.##..#.....
..#....#..............#....#...
..#.#.#.....##.#.....#..##.....
....#.....#....#...#...#..#.#..
#...#...........#..#..#........
...#.#..#.........##.#...#..##.
......#.#.........#.#...#......
......#..##.###......##.#....#.
.....#...#..#.......#..........
.#...#.......#.....###......#..
...........##.....#..#..#....#.
..#....#..#...#......#.......#.
..#...#...#.#..#....#...#......
.......#....###.####...###.#...
#.##.#.......#.......#....#.#.#
.##..........#.....#..###......
.....#...........#.##..#....#..
........##.....#.#........##...
#..#..#..................##....
#...###..........#.............
.......#.#.......#.#.......##..
.....#.#...#....#...####.....#.
..##.....##.......#....#.......
##..........#...#..##....##....
..........#..#......#........#.
##..#....#..#....#.....##....#.
##.##.....#...##.##.......#....
..#..#.###.#..##.#..#..#...#...
.#..#.....#........#...##.#....
..#..#.....#.#......##.#.#.....
.#..##...#.#....#...#...#.#.##.
.........#...#....###.#.....#..
...........###.#.#..#..#...#.#.
##...#......##...........#..#..
.........##..#...#.......#.....
#......#.#..........#..#.......
...#.................#....#....
#....#......................##.
##.......#..#......#.#...###.#.
..#....#..#.#......#...........
...#...........###.#.#.........
..#..##.....#.....##...##......
..#..#.#.#.#..#..#..##....#...#
#......##.....##..##.##...#....
#.....#.....#.#........#.......
.#.....#.................#....#
.###....#...#............#.#.#.
.#...#.#......#.#..............
....#...#......#.....#.......#.
........#.....#..........#....#
#..#......#...#...#.........#..
#....#......#...##.#...#...#...
#...#....#....#..#..#.....#..#.
#......##..#..#.#.#..#.#.......
..#..#...............#...##...#
............#..............#.##
.#.#.#......##.......#.......#.
....#.........##.......#...###.
.......#.#...#.#.#.......#.....
....#..#..#...#....#.##.#.##...
...##.##.#...#......#..........
#.....#...#.#...#.##..##.#.....
.......#.....#...#.#...##.#....
.#.............#.....#....##..#
##......#.......#...#....#.....
.###......#.................#..
#.#......##.........##..#......
...#....#..........#.#.........
..##..#.........#..............
.....#...#..................#.#
.............#.........#...#..#
....#....#......#.#.......#...#
#..#............#.#.......#...#
..#.....#............#.........
.#.....................###....#
........#.####.........#.#.#...
#...........##...#.........#..#
...........#..#......#...#.#...
....##...##.....#.....#........";
    }
}