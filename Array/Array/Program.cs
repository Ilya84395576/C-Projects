namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NumberOfAllStudents = 0;
            uint numberOfGroups;
            Console.WriteLine("Enter number of groups: ");
            numberOfGroups = uint.Parse(Console.ReadLine());

            int[][] group = new int[numberOfGroups][];
            Console.WriteLine();

            for (int i = 0; i < numberOfGroups; i++)
            {
                Console.WriteLine("Enter number of students for group #" + (i + 1) + ": ");
                uint numberOfStudents = uint.Parse(Console.ReadLine());

                group[i] = new int[numberOfStudents];
            }

            Console.WriteLine();

            for (int i = 0; i < group.Length; i++)
            {
                for (int j = 0; j < group[i].Length; j++)
                {
                    NumberOfAllStudents++;
                    Console.WriteLine("Enter the student's grade [" + i + "]" + "[" + j + "]");
                    group[i][j] = int.Parse(Console.ReadLine());
                }
            }

            double[] averageGradeForGroups = new double[numberOfGroups]; 
            for (int i = 0; i < group.Length; i++)
            {
                double Sum = 0;
                double Result = 0;
                for (int j = 0; j < group[i].Length; j++)
                {
                    Sum += group[i][j];
                    Result = Sum / group[i].Length;
                }

                averageGradeForGroups[i] = Result;
            }

            int[] minGradeForGroups = new int[numberOfGroups];
            for (int i = 0; i < group.Length; i++)
            {
                int min = group[i][0];
                for (int j = 1; j < group[i].Length; j++)
                {
                    if (group[i][j] < min)
                    {
                        min = group[i][j];
                    }
                }

                minGradeForGroups[i] = min;
            }

            int[] maxGradeForGroups = new int[numberOfGroups];
            for (int i = 0; i < group.Length; i++)
            {
                int max = group[i][0];
                for (int j = 1; j < group[i].Length; j++)
                {
                    if (group[i][j] > max)
                    {
                        max = group[i][j];
                    }
                }

                maxGradeForGroups[i] = max;
            }

            Console.WriteLine();

            for (int i = 0; i < averageGradeForGroups.Length; i++)
            {
                Console.WriteLine("Average grade for group #" + i + " = " + averageGradeForGroups[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < minGradeForGroups.Length; i++)
            {
                Console.WriteLine("Minimum grade for group #" + i + " = " + minGradeForGroups[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < maxGradeForGroups.Length; i++)
            {
                Console.WriteLine("Maximum grade for group #" + i + " = " + maxGradeForGroups[i]);
            }

            double averageGradeForAllGroups = 0;
            double SumG = 0;
            for (int i = 0; i < group.Length; i++)
            {
                for(int j = 0;  j < group[i].Length; j++)
                {
                    SumG += group[i][j];
                }
            }
            averageGradeForAllGroups = SumG / NumberOfAllStudents;

            int minG = minGradeForGroups[0];
            for (int i = 0; i < minGradeForGroups.Length; i++)
            {
                if (minG > minGradeForGroups[i])
                {
                    minG = minGradeForGroups[i];
                }
            }

            int maxG = maxGradeForGroups[0];
            for (int i = 0; i < maxGradeForGroups.Length; i++)
            {
                if (maxG < maxGradeForGroups[i])
                {
                    maxG = maxGradeForGroups[i];
                }
            }

            Console.WriteLine();

            Console.WriteLine("Average grade for all groups = " + averageGradeForAllGroups);
            Console.WriteLine("Minimum grade for all groups = " + minG);
            Console.WriteLine("Maximum grade for all groups = " +  maxG);
        }
    }
}
