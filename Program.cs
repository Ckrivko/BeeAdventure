using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int[] beeIndex = new int[2];
            int pollinate = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeIndex[0] = row;
                        beeIndex[1] = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {

                int currRow = beeIndex[0];
                int currCol = beeIndex[1];

                beeIndex = GetMove(matrix, command, beeIndex);
                matrix[currRow, currCol] = '.';

                if (IsOutMAtrix(beeIndex, matrix))
                {

                    Console.WriteLine("The bee got lost!");
                    break;
                }

                else
                {
                    currRow = beeIndex[0];
                    currCol = beeIndex[1];

                    if (matrix[currRow, currCol] == 'f')
                    {
                        pollinate++;

                    }

                    else if (matrix[currRow, currCol] == 'O')
                    {
                        matrix[currRow, currCol] = '.';
                        beeIndex = GetMove(matrix, command, beeIndex);

                        currRow = beeIndex[0];
                        currCol = beeIndex[1];

                        if (matrix[currRow, currCol] == 'f')
                        {
                            pollinate++;

                        }
                                                
                    }

                    matrix[currRow, currCol] = 'B';

                }

                command = Console.ReadLine();
            }

            if (pollinate >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinate} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinate} flowers more");
            }

            PrintMatrix(matrix);

        }

        public static int[] GetMove(char[,] matrix, string command, int[] beeIndex)
        {
            // "up", "down", "left", "right", "End".


            if (command == "up")
            {
                beeIndex[0] -= 1;
            }
            if (command == "down")
            {
                beeIndex[0] += 1;
            }
            if (command == "left")
            {
                beeIndex[1] -= 1;
            }
            if (command == "right")
            {
                beeIndex[1] += 1;
            }

            return beeIndex;
        }

        public static bool IsOutMAtrix(int[] beeIndex, char[,] matrix)
        {
            if (beeIndex[0] < 0 || beeIndex[0] >= matrix.GetLength(0)
                || beeIndex[1] < 0 || beeIndex[1] >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }                

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();
            }
        }
    }
}
