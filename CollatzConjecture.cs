using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            int x;

            while (input != "")
            {
                x = int.Parse(input); 
                int steps = NumOfSteps(x);
                Console.WriteLine("Steps: " + steps);
                Console.WriteLine("Enter a number: "); 
                input = Console.ReadLine();
            }
            Console.ReadLine();
        }
        public static int NumOfSteps(int num)
        {
            //*****RECURSIVE SOLUTION*****
            if (num == 1)
                return 0;
            if (num % 2 == 0)
                return RecursiveProblem(num / 2) + 1;
            return RecursiveProblem((3 * num) + 1) + 1;
            //****************************

            /*****REGULAR SOLUTION*****
            int steps = 0;
            while (num != 1)
            {
                if (num % 2 == 0)
                    num = num / 2;
                else
                {
                    num = num * 3;
                    if (num > 0)
                        num += 1;
                    else num -= 1;
                }
                steps++;
            }
            return steps;
            *************************/
        }
    }
}
