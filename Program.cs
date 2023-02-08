using System.Reflection.Metadata;

namespace ConsoleApp1
{
    enum WindowsSize : int
    {
        Left = 19,
        Right = 39
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize((int)WindowsSize.Right+1, (int)WindowsSize.Left+1);
            Console.SetBufferSize((int)WindowsSize.Right+1, (int)WindowsSize.Left+1);
            Console.CursorVisible = false;
            bool start = true;

            Snake sn = new Snake();
            Thread th = new Thread(_ =>
            {
                Console.WriteLine();
                while (start)
                {
                    List<Snake> snake = new List<Snake>
                    {
                        new Snake
                        {
                            Body = 'Q',
                            PosY = 3,
                            PosX = 3
                        },
                        new Snake
                        {
                            Body = '#',
                            PosY = 3,
                            PosX = 2
                        },
                        new Snake
                        {
                            Body = '#',
                            PosY = 3,
                            PosX = 1
                        }
                    };
                    while (sn.StartGame)
                    {
                        sn.DrewSnake(snake);
                        Thread.Sleep(100);
                        snake = sn.MoveSnake(snake);
                        if (snake.Count() == (int)WindowsSize.Left*(int)WindowsSize.Right)
                        {
                            sn.StartGame = false;
                        }
                    }
                }
            });
            th.Start();
            while (start)
            {
                Console.Clear();
                Console.WriteLine("Чтобы начать нажмите любую клавишу, чтобы выйти нажмите Ecape");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                for (int i = 0; i < (int)WindowsSize.Left-1; i++)
                {
                    Console.SetCursorPosition((int)WindowsSize.Right - 1, i);
                    Console.Write("||");
                }
                for (int i = 0; i < (int)WindowsSize.Right-1; i++)
                {
                    Console.SetCursorPosition(i,(int)WindowsSize.Left - 2 );
                    Console.Write("!");
                }
                sn.AddApple(Apple.CreateApple());
                sn.StartGame = true;
                if (key.Key == ConsoleKey.Escape)
                {
                    start = false;
                }
                while (sn.StartGame)
                {
                    sn.ChaseDirection(Console.ReadKey());
                }
            }
        }
    }
}