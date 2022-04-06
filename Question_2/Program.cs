using System;
using System.Collections.Generic;
using System.Threading;

namespace Question_2
{
    class Program
    {
         static Random rnd = new Random();
        // girilen bir int sayıyı rakamlarına ayırıp toplama veya çıkartma işlemleri ile 0'a eşitleniyor mu kontrol edilecek bir algoritma geliştirme !
        static void Main(string[] args)
        {
            int number = GetRandomNumber();
            Console.WriteLine($"Number is {number}");
            var numbers = CheckDigits(number);

            var possibility = CalculatePosibility(numbers);

            var results = PlusMinus(numbers, possibility);

            Console.WriteLine("---------------------------------------------");
            foreach (var result in results)
            {
                Console.Write($"{result}  ");
            }

        }
        // Kaç İhtimal olacağını hesaplama
        private static int CalculatePosibility(List<int> numbers)
        {
            int digit = numbers.Count-1;
            int possibility = 2;
            for (int i = 1; i < digit; i++)
            {
                possibility *= 2;
            }
            Console.WriteLine($"Possibility is {possibility}");

            return possibility;
        }
        // Rastgele bir sayı üretma
        private static int GetRandomNumber()
        {
           
            var number = rnd.Next(1, 10000);
            return number;
        }

        //Rastgele üretilen bir sayıyı rakamlara ayırma
        private static List<int> CheckDigits(int number)
        {
            List<int> listOfDigit = new List<int>();
            int digit = 0;
            if (number/10!=0)
            {
                while(number/10 != 0)
                {
                    digit = number % 10;
                    number = number / 10;
                    listOfDigit.Add(digit);                   
                }
                if (number != 0)
                    listOfDigit.Add(number);
            }
            else
            {
                Console.WriteLine("Number is lower than 10");
            }
            return listOfDigit;
        }

        private static List<int> PlusMinus(List<int> numbers, int possibility)
        {
            int result = numbers[0];
            int countOfOperations = 0;
            List<int> listOfResult = new List<int>();
            if (possibility != 0)
            {
                while(possibility != 0)
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        // Artı mı yoksa eksimi olacak ?
                        int probabiltyOfPlusOrMinus = rnd.Next(1, 3);
                        if (probabiltyOfPlusOrMinus == 1)
                        {
                            Console.WriteLine($"{result} + {numbers[i]}");
                            result += numbers[i];
                        }
                        else
                        {
                            Console.WriteLine($"{result} - {numbers[i]}");
                            result -= numbers[i];
                        }
                        countOfOperations++;
                    }
                    Console.WriteLine("------------------------------------");
                    listOfResult.Add(result);
                    result = numbers[0];
                    possibility--;
                }
            }
            
            return listOfResult;
        }
    }
}
