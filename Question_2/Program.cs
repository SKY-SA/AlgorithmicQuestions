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
            
            List<int> listOfResult = new List<int>();
            List<int> orderOfOperations = new List<int>();
            // Artı mı Yoksa Eksi mi gelecek bulmak için rastgele üretilecek sayının tutulduğu değişken
            int probabiltyOfPlusOrMinus = -1;
            // Verilen sayı rakama ayrıldığı zaman yapılan bir işlemde kaç adet "-" veya "+" olduğunu tutan değişken
            int countOfOrder = numbers.Count - 1;
            //Gruplara ayrıldıktan sonra birbiriyle kaç defa karşılaştırılacağını tutan değişken
            int probabilityOfOrder = 0;
            int x = 0;
            int y = 0;
            if (possibility != 0)
            {
                while(possibility != 0)
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        // Artı mı yoksa eksimi olacak ?
                        probabiltyOfPlusOrMinus = rnd.Next(0, 2);
                        if (probabiltyOfPlusOrMinus == 0)
                        {
                            Console.WriteLine($"{result} + {numbers[i]}");
                            result += numbers[i];
                        }
                        else if(probabiltyOfPlusOrMinus == 1)
                        {
                            Console.WriteLine($"{result} - {numbers[i]}");
                            result -= numbers[i];
                        }
                        orderOfOperations.Add(probabiltyOfPlusOrMinus);
                    }
                    // İşlem Sırasında kullanılan "+" veya "-" adetinin kaçarlı gruplandırıldığını belirleyip ve bu sayıya(kaç grup olduğunu belirten) göre kaç adet olasılık olacağını 
                    // (yapılan işlemlerin aynı olup olmadığını kontrol edilmesi için bu listedeki sayıların grup halinde kaç defa birbiriyle karşılaştırılması gerektiğini) hesaplayacığız.


                    var combination = orderOfOperations.Count / countOfOrder;
                    probabilityOfOrder = (combination * (combination - 1)) / 2;
                    //Console.WriteLine("------------------------------------");
                    
                    while (probabilityOfOrder != 0)
                    {
                       while(countOfOrder != 0)
                        {
                            y = x + countOfOrder;
                            if(orderOfOperations[x] == orderOfOperations[y])
                            {
                            }
                            x++;
                        }
                       
                    }
                    // Eğer bir önceki işlemler ile aynı şekilde değilse ekle 
                    listOfResult.Add(result);
                    result = numbers[0];
                    possibility--;
                }
            }
            
            return listOfResult;
        }
    }
}
