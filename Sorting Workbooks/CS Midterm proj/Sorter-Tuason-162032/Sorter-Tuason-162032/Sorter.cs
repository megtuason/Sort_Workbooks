using System;
namespace SorterTuason162032
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
				int loc = BinarySearch(arr, i - 1, temp);
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

		public int BinarySearch(int[] arr, int end, int target)
		{
			int start = 0;
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
		}

        public int[] BubbleSort (int [] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
				for (int z = 0; z < arr.Length - 1; z++)
				{
					if (arr[z] > arr[z + 1])
					{
						int old = arr[z];
						arr[z] = arr[z + 1];
						arr[z + 1] = old;
						for (int j = 0; j < arr.Length; j++)
						{
							Console.Write(arr[j] + " ");
						}
						Console.WriteLine();
					}
				}
            }
			return arr;
        }
    }
}
