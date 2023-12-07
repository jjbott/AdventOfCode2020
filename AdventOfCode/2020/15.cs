using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _15
    {
        public void RunA()
        {
            //input = testCase2;

            var numbersToTurn = new Dictionary<int, int>();
            var lastNumber = 0;

            var turn = 1;
            foreach(var init in input.Split(",").Select(d => int.Parse(d)))
            {
                numbersToTurn[init] = turn;
                lastNumber = init;
                ++turn;
            }

            while(turn <= 2020)
            {
                var nextNumber = 0;
                if (!numbersToTurn.ContainsKey(lastNumber)  || numbersToTurn[lastNumber] == (turn - 1))
                {
                    // number never said before

                    nextNumber = 0;
                }
                else
                {
                    nextNumber = (turn-1) - numbersToTurn[lastNumber];
                }

                numbersToTurn[lastNumber] = (turn - 1);

                lastNumber = nextNumber;
                turn++;
            }

            Console.WriteLine(lastNumber);

        }

        public void RunB()
        {
            //input = testCase1;

            var numbersToTurn = new Dictionary<Int64, Int64>();
            Int64 lastNumber = 0;

            Int64 turn = 1;
            foreach (var init in input.Split(",").Select(d => int.Parse(d)))
            {
                numbersToTurn[init] = turn;
                lastNumber = init;
                ++turn;
            }

            while (turn <= 30000000)
            {
                Int64 nextNumber = 0;
                if (!numbersToTurn.ContainsKey(lastNumber) || numbersToTurn[lastNumber] == (turn - 1))
                {
                    // number never said before

                    nextNumber = 0;
                }
                else
                {
                    nextNumber = (turn - 1) - numbersToTurn[lastNumber];
                }

                numbersToTurn[lastNumber] = (turn - 1);

                lastNumber = nextNumber;
                turn++;
            }

            Console.WriteLine(lastNumber);

        }


        private string testCase1 = "0,3,6";
        private string testCase2 = "1,3,2";
        private string input = "0,1,4,13,15,12,16";
    }
}
