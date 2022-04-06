using System;

namespace SecondGreatestLow
{
    class Program
    {

        public static int SecondGreatest(int[] arr)
        {
            int max1, max2;
            max1 = arr[0];
            max2 = arr[1];

            for (int i = 1; i < arr.Length; i++)
            {  
                if (arr[i] > max1)
                {
                    max2 = max1;
                    max1 = arr[i];
                }
                else if (arr[i] > max2)
                    max2 = arr[i];
            }
            return max2;
        }

        public static int SecondLow(int[] arr)
        {
            int min1, min2;
            min1 = arr[0];
            min2 = arr[1];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min1)
                {
                    min2 = min1;
                    min1 = arr[i];
                }
                else if (arr[i] < min2)
                    min2 = arr[i];
            }
            return min2;
        }
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1000,118,10,1, 2,5,6,7,111,8,1222 };
            Console.WriteLine(SecondLow(numbers));
            //Console.WriteLine(SecondGreatest(numbers));
        }
    }
}
