using System;
namespace SorterTuason162032Navarrete161413
{
    public class Sorter
    {
        public Sorter()
        {
        }
		public int[] BiSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				int temp = arr[i];
				int z = i;
                int loc = BinarySearch(arr, i - 1, temp, 0);
				while ((z > loc) && (arr[z - 1] > temp))
				{
					arr[z] = arr[z - 1];
					z--;
				}
				arr[z] = temp;
				for (int j = 0; j < arr.Length; j++)
				{
					Console.Write(arr[j] + " ");
				}
				Console.WriteLine();
			}
			return arr;
		}

		public int BinarySearch(int[] arr, int end, int target, int start)
		{
            Console.WriteLine("help");
            int mid = (start + end) / 2;
            if (start == end)
            {
                return mid;
            }
            else if (arr[mid] > target)
            {
                return BinarySearch(arr, mid - 1, target, start);
            }
            else if (arr[mid] < target)
            {
                return BinarySearch(arr, end, target, mid + 1);
            }
            return mid;
            /*
			int mid = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				mid = (start + end) / 2;
				if (start == end)
				{
					i = arr.Length - 1;
				}
				else if (arr[mid] > target)
				{
					end = mid - 1;
				}
				else if (arr[mid] < target)
				{
					start = mid + 1;
				}
			}
			return mid;
			*/
		}

		public int[] BubbleSort(int[] arr, int counter, int countertwo)
		{
            if (countertwo == arr.Length - 1)
            {
                return arr;
            }
            else if (counter == arr.Length - 1)
            {
                return BubbleSort(arr, 0, countertwo + 1);
            }
            else if (arr[counter] > arr[counter + 1])
            {
                int old = arr[counter];
                arr[counter] = arr[counter + 1];
                arr[counter + 1] = old;
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
            }
            return BubbleSort(arr, counter + 1, countertwo);
		}
    }
}
