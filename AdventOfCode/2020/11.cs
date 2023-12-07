﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _11
    {
        int countAdjacentOccupied(char[][] data, int x, int y)
        {
            var count = 0;
            if (y > 0 && x > 0 && data[y - 1][x - 1] == '#') ++count;
            if (y > 0 && data[y - 1][x] == '#') ++count;
            if (y > 0 && x < data[0].Length-1 && data[y-1][x +1] == '#') ++count;
            if (x > 0 && data[y][x - 1] == '#') ++count;
            if (x < data[0].Length-1 && data[y][x + 1] == '#') ++count;
            if (y < data.Length-1 && x > 0 && data[y + 1][x - 1] == '#') ++count;
            if (y < data.Length-1 && data[y + 1][x] == '#') ++count;
            if (y < data.Length-1 && x < data[0].Length-1 && data[y + 1][x + 1] == '#') ++count;
            return count;
        }

        public void RunA()
        {
            var data = input.Split("\r\n").Select(l => l.ToCharArray()).ToArray();

            var numChanges = 0;
            do
            {
                numChanges = 0;
                var newData = new char[data.Length][];
                for(int y = 0; y < data.Length; ++y)
                {
                    newData[y] = new char[data[0].Length];
                    for (int x = 0; x < data[0].Length; ++x)
                    {
                        newData[y][x] = data[y][x];

                        if ( data[y][x] == 'L' && countAdjacentOccupied(data, x, y) == 0)
                        {
                            newData[y][x] = '#';
                            numChanges++;
                        }
                        else if (data[y][x] == '#' && countAdjacentOccupied(data, x, y) >= 4)
                        {
                            newData[y][x] = 'L';
                            numChanges++;
                        }
                    }
                }
                data = newData;
                Console.WriteLine(data[0]);
            } while (numChanges > 0);

            foreach(var l in data)
            {
                Console.WriteLine(new string(l) + " " + l.Count(c => c == '#'));
            }

            var count = data.Select(y => y.Count(c => c == '#')).Sum();
            Console.WriteLine(count);
        }

        public bool CanSeeOccupied(char[][] data, int x, int y, int dx, int dy)
        {
            x += dx;
            y += dy;
            while (y >= 0 && x >= 0 && y < data.Length && x < data[0].Length )
            {
                if (data[y][x] == '#') return true;
                if (data[y][x] == 'L') return false;
                x += dx;
                y += dy;
            }
            return false;
        }

        public int CanSeeOccupied(char[][] data, int x, int y)
        {
            var count = 0;
            if (CanSeeOccupied(data, x, y, -1, -1)) ++count;
            if (CanSeeOccupied(data, x, y, 0, -1)) ++count;
            if (CanSeeOccupied(data, x, y, 1,-1)) ++count;
            if (CanSeeOccupied(data, x, y, -1, 0)) ++count;
            if (CanSeeOccupied(data, x, y, 1, 0)) ++count;
            if (CanSeeOccupied(data, x, y, -1, 1)) ++count;
            if (CanSeeOccupied(data, x, y, 0, 1)) ++count;
            if (CanSeeOccupied(data, x, y, 1, 1)) ++count;
            
            return count;
            

        }


        public void RunB()
        {
            var data = input.Split("\r\n").Select(l => l.ToCharArray()).ToArray();

            var numChanges = 0;
            do
            {
                numChanges = 0;
                var newData = new char[data.Length][];
                for (int y = 0; y < data.Length; ++y)
                {
                    newData[y] = new char[data[0].Length];
                    for (int x = 0; x < data[0].Length; ++x)
                    {
                        newData[y][x] = data[y][x];

                        if (data[y][x] == 'L' && CanSeeOccupied(data, x, y) == 0)
                        {
                            newData[y][x] = '#';
                            numChanges++;
                        }
                        else if (data[y][x] == '#' && CanSeeOccupied(data, x, y) >= 5)
                        {
                            newData[y][x] = 'L';
                            numChanges++;
                        }
                    }
                }
                data = newData;
                Console.WriteLine(data[0]);
            } while (numChanges > 0);

            foreach (var l in data)
            {
                Console.WriteLine(new string(l) + " " + l.Count(c => c == '#'));
            }

            var count = data.Select(y => y.Count(c => c == '#')).Sum();
            Console.WriteLine(count);
        }

        private string input = @"LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLLL.LLLLLLLLLLLL.LL.LLLLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLL..LLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLL.L.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
..LLL..L.L..LL...LL......L..LL..L..LL........L.....LLLL.L.L.L.........L.L..L.L.....L..L............
LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLL.LLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLL.LLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL
....L..LL...L.L.L.......LL....L.....L..L...L.L.L....LL.L..L...LL...L....L..L...L.............LL..LL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLL.L.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLL.L.LLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLL..LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLL.LLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.L.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLL
..L...L.L....L........L.......L.L...L..L.LL.........L.......LLL.LL.L...LL....L..L.L.L.LL.....L.....
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLLLL.LLLLLLLLLLLLLLLL
LLLLLLL..LLLLLLLL.LLLLLL.LLLLLLL.LLLL.L.LLLLLLL.LLLLL.LLLLLLL.LLLL.LL.L.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLL.L.L.LLLLL.LLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLL.LLLLLL.LLLLL..LLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
L......L..L...L....L...L...L...L...L..LL...L......LL......LL......LLLL..L.....LL...L.LL..L....LL..L
LLLLLLL.LLLLLLLLL.LLLLLL..LLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLL.LLLLLLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLL.LLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLL.LLL.LLLLL.LLLLLLL.LL.L.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL.L.LLL.LLLLLLL.LLLL.LLLL..LLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.L.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
L....L...L....L...L.....L....L.LL..L..L.LL.L..L..LL...LL..L......L...L.LL...L.L.....L.L.LLL.LL.L.L.
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLL.LLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLL..LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLL..LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLL..LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
........L........L......L...L...L.L.....L..L..LL.L..L.L.LLL.L..L..L.L.LL.L.LL......L...L..LLL....L.
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLL.LL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.L.LL.LLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLL..LLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL..LLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLLLLLLL.L..LLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLL.L.LLLL.LLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
..LL..L......L.L.L...LL.L.LLL.L.....LLL..LL...L...L.L.LL....L.....L.LL..LLL...LL...L.....LLL.L..LL.
LLLLLLL.LLLLLLL.L.LLLLLL.LLLLLLL..LLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLL.LL.L.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLL..LLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLL..LLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
..L..L.L....L.L..L.L.LL......LLL.L...L..L..L..........LL.......L...LL.L.L.L...L.......L........L...
LLLLLLLLLLLL.LLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLL.L.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLL.LLL.LLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLL.LLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLL.LLL.
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLL.L.LLLLLLLLL.LLLLL..LLLLLLL.LLLL.LLLL.LLLL.LLLLL.LLLLLLL.LLLL.LLLL.LL.LLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
..L.......L..LL.L..L..LLLLL..L...L.L.L....L...L.LL.L.......L.....LL.........L.L......L.L..L.....L..
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLL.LLLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
L...LL.L..LLLL.LLL.L....L......L.............LL.....L...LL.L...L.L......LL....L......L...LL.L.....L
LLLLLLL.LLLLLLLLL.LLLLLL.L.LLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.L.LL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLL.LLLLLL.LL.LLLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLLLL.LLLLLL.LLLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLL.LLLLLLLL.LLLLLLLL.LLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLL.LLLL.LLLLL.LLLLLLL.LLLL.L.LLLLLLLLLLL.LLLLLL.L.LLLLLLLLL";
    }
}