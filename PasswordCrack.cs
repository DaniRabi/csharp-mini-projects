using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This program is the brute-force method of cracking a password.
 * The algorithm goes through every possible combination of a
 * password the same length as the input given (which is the password).
 * If one of the possible combinations is the same as the password, True is returned
 * and then printed. Otherwise, False will be returned and printed.
 * The password may include characters between placement 33 and 126 in the ASCII table.
     */
namespace PasswordCrack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
            while (pass != "")
            {
                char[] g = new char[pass.Length];
                for (int i = 0; i < g.Length; i++)
                    g[i] = (char)33; // '!';
                string guess = "";
                foreach (char c in g)
                    guess += c;
                Console.WriteLine(CheckPass(pass, guess));

                Console.WriteLine("Enter Password: ");
                pass = Console.ReadLine();
            }
        }
        public static string IncrementLetter(string word, int i)
        {
            if (i < word.Length)
            {
                char[] chars = word.ToCharArray();
                char c = chars[i];
                if (c == (char)126) // '~'
                    chars[i] = (char)33; // '!';
                else chars[i] = (char)(c + 1);
                return string.Join("", chars); // guess = new string(chars);
            }
            return word;
        }
        public static bool CheckPass(string pass, string guess)
        {
            return CheckPassHelp(pass, guess, 0);
        }
        public static bool CheckPassHelp(string pass, string guess, int index)
        {
            // if the password is found then True will be returned, if not -> False
            for (int i = 1; i <= 93; i++) // 126 - 33 = 93
            {
                if (guess == pass)
                    return true;

                if (index < pass.Length - 1 && CheckPassHelp(pass, guess, index + 1))
                        return true;

                guess = IncrementLetter(guess, index);
            }
            return false;
        }
    }
}
