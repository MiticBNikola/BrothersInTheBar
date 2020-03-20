using System;
using System.Linq;

namespace BrothersInTheBar
{
    class Program
    {
        public int brothersInTheBar(int[] glasses)
        {
            int result = 0;
            int[] front;
            int[] back;
            int n = glasses.Length;
            int i = 0;
            while (n >= 3 && i < n - 2)
            {
                if (glasses[i] == glasses[i + 1] && glasses[i + 1] == glasses[i + 2])
                {
                    result++;
                    front = glasses.Take(i).ToArray();
                    back = glasses.Skip(i + 3).Take(n - i - 3).ToArray();
                    front.CopyTo(glasses, 0);
                    back.CopyTo(glasses, front.Length);
                    n = glasses.Length;
                    if (i > 1)
                    {
                        if (glasses[i - 2] == glasses[i - 1])
                            i = i - 2;
                        else
                            i = i - 1;
                    }
                    else
                        i = 0;
                }
                else if (glasses[i + 1] == glasses[i + 2])
                {
                    i++;
                }
                else
                {
                    i = i + 2;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            int[] glasses = new int[] { 1, 1, 2, 3, 3, 3, 2, 2, 1, 1 };
            int result = 0;
            result = myProgram.brothersInTheBar(glasses);
            Console.WriteLine("Number of rounds is " + result);
            Console.ReadLine();
        }
    }
}
