using System;

namespace Trainee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string[] stringnumbers = Console.ReadLine().Split(' ');
            int[] numbers = new int[day];
            for (int i = 0; i < day; i++)
            {
                numbers[i] = int.Parse(stringnumbers[i]);
            }
            int sum = 0;
            int answer = 0;
            int lasti = 0;
            int repeat = 0;
            for (int i = 0; i < day; ++i)
            {
                sum = numbers[i];
                for (int j = i + 1; j < day; ++j)
                {
                    sum = sum + numbers[j];
                    if (sum == 0)
                    {
                        if (i == 0)
                        {
                            answer = answer + day - j + 1;
                        }
                        else
                        {
                            answer = answer + (i - lasti) * (day - j + 1);
                        }
                        lasti = i;
                        repeat++;
                    }
                }
            }
            Console.WriteLine(answer - repeat);
        }
    }
}