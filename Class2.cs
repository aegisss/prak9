using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Apple
    {
        public char Body;
        public int PosX;
        public int PosY;

        public static Apple CreateApple()
        {
            Random rnd = new Random();
            Apple al = new Apple
            {
                Body = 'X',
                PosX = rnd.Next(1, Console.WindowWidth - 2),
                PosY = rnd.Next(1, Console.WindowHeight - 3)
            };
            Console.SetCursorPosition(al.PosX, al.PosY);;
            Console.WriteLine(al.Body);
            return al;
        }
    }
}
