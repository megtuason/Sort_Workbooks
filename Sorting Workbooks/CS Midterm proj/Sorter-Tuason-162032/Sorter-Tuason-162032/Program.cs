using System;

namespace SorterTuason162032
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Sorter sort = new Sorter();
            int choice;
            do
            {
                Console.WriteLine("=====SORTER=====" + "\n" + "Enter values to be sorted");
                string input = (Console.ReadLine());
                string[] integers = input.Split(' ');
                int[] numbers = Array.ConvertAll(integers, int.Parse);

                Console.WriteLine("How do you want it to be sorted?" + "\n" + "1 BInsertion Sort" + "\n" + "2 Bubble Sort" + "\n" + "0 Exit");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    sort.BiSort(numbers);
                    Console.WriteLine();
                }
                else if (choice == 2)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                    Console.WriteLine();
                    sort.BubbleSort(numbers);
                    Console.WriteLine();
                }
            }
            while (choice != 0);
        }
    }
}
