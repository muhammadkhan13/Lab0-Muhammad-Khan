// Lab0
// Muhammad Khan
// 000928379
// Dec 13 2024

using System;
using System.Collections.Generic;
using System.IO;

namespace Lab0 
{ 
    class Program 
    {
        static double LowValidation()
        {
            double low = Convert.ToDouble(Console.ReadLine());
            while (low < 1)
            {
                Console.WriteLine("Invalid input, please enter a number greater than 0:");
                low = Convert.ToDouble(Console.ReadLine());
            }
            return low;
        }

        static double HighValidation(double low)
        {
            double high = Convert.ToDouble(Console.ReadLine());
            while (high <= low)
            {
                Console.WriteLine("Invalid input, please enter a number greater than the previous number:");
                high = Convert.ToDouble(Console.ReadLine());
            }
            return high;
        }

        static bool PrimeCheck(double num)
        {
            bool prime = true;
            Convert.ToInt32(num);
            if (num == 0 || num == 1)
            {
                prime = false;
            }

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    prime = false;
                }
            }
            return prime;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter a low number:");
            double lowNumber = LowValidation();

            Console.WriteLine("Enter a high number:");
            double highNumber = HighValidation(lowNumber);

            double difference = highNumber - lowNumber;
            Console.WriteLine("The difference between the two numbers is " + difference);

            List<double> numberList = new List<double>();
            for (double i = (lowNumber + 1); i < highNumber; i++)
            {
                numberList.Add(i);
            }
            numberList.Reverse();

            foreach (double number in numberList)
            {
                File.AppendAllText("numbers.txt", number.ToString());
            }

            double fileNumbers = Convert.ToDouble(File.ReadAllText("numbers.txt"));
            List<double> fileList = new List<double>();
            while (fileNumbers > 0)
            {
                double digit = fileNumbers % 10;
                fileList.Add(digit);
                fileNumbers = (fileNumbers - digit) / 10;
            }

            double fileSum = 0;
            foreach (double number in fileList)
            {
                fileSum += number;
            }
            Console.WriteLine("The sum of the numbers between the low number and high number is "+fileSum.ToString());

            Console.WriteLine("Here is the list of prime numbers between the low number and high number:");
            foreach (double number in numberList)
            {
                if (PrimeCheck(number))
                {
                    Console.WriteLine(number.ToString());
                }
            }
        }
    }
}