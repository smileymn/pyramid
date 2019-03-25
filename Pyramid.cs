using System;
using System.Linq;
using System.Collections.Generic;


namespace Akeneo
{
    public class Pyramid
    {
        /**pyramid loaded from file */
        private int[][] pyramid;

        /**sums of allowed paths. Key is sum, value is num of occurences */
        private Dictionary<int, long> sums;

        /** loads pyramid from text file to data structure **/
        public void Load(string[] inputLines)
        {
            int i = 0, rowsNumber = inputLines.Length;

            this.resetPyramid();
            this.pyramid = new int[rowsNumber][];
            inputLines.ToList().ForEach(row =>
            {
                string[] rowNumbersStrings = row.Split(" ");
                List<int> numbers = new List<int>();

                rowNumbersStrings.ToList().ForEach(s =>
                {
                    int n = 0;

                    if (Int32.TryParse(s, out n))
                    {
                        numbers.Add(n);
                    }
                    else
                    {
                        //throw error
                        throw new Exception("Invalid pyramid file");
                    }
                });

                this.pyramid[i++] = numbers.ToArray();
            });

            this.Print();

        }

        /**prints pyramid */
        public void Print()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Pyramid:");
            this.pyramid.ToList().ForEach(l => { l.ToList().ForEach(x => Console.Write(x + " ")); Console.WriteLine(); });
        }

        /** returns sums and count of  occurences of the sums**/
        public void GetSumsAndCounts()
        {
            this.calcPathsSums(0, 0, 0); //start from top of pyramid
            this.PrintSums();
        }

        /**calculates allowed available paths sums  */
        private void calcPathsSums(int memberRow, int memberCol, int sumUntilRow, string path = "")
        {
            //Top to bottom aproach - top of pyramid
            if (memberRow == this.pyramid.GetLength(0) - 1) //arrived buttom
            {
                int newSum = sumUntilRow + this.pyramid[memberRow][memberCol];

                if (this.sums.ContainsKey(newSum))
                {
                    this.sums[newSum]++; //increase count of occurences
                }
                else
                {
                    this.sums.Add(newSum, 1);
                }
            }
            else
            {
                this.calcPathsSums(memberRow + 1, memberCol, sumUntilRow + this.pyramid[memberRow][memberCol], path);
                this.calcPathsSums(memberRow + 1, memberCol + 1, sumUntilRow + this.pyramid[memberRow][memberCol], path);
            }
        }

        public void PrintSums()
        {
            this.sortSumsByCount();
            Console.WriteLine("*******************************");
            Console.WriteLine("Sum | Count");
            this.sums.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Key.ToString() + " | " + x.Value);
            });
        }

        private void resetPyramid()
        {
            this.sums = new Dictionary<int, long>();
            this.pyramid = null;
        }

        private void sortSumsByCount()
        {
            var list = this.sums.ToList();
            list.Sort((x, y) => y.Value.CompareTo(x.Value));
            this.sums = list.ToDictionary(x => x.Key, x => x.Value);
        }

    }
}
