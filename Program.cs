using System;

namespace MatrixRain
{
    class Program
    {
        static int Counter;
        static Random randomPosition = new Random();

        static int flowspeed = 100;
        static int fastFlow = flowspeed + 30;
        static int textFlow = fastFlow + 50;

        static ConsoleColor baseColor = ConsoleColor.DarkGreen;
        static ConsoleColor greenColor = ConsoleColor.Green;
        static ConsoleColor fadedColor = ConsoleColor.White;

        static String endText = "It's Source World~!";

        static char AsciiCharacters
        {
            get
            {
                int t = randomPosition.Next(10);

                if (t <= 2) return (char)('0' + randomPosition.Next(10));
                else if (t <= 4) return (char)('a' + randomPosition.Next(27));
                else if (t <= 6) return (char)('A' + randomPosition.Next(27));
                else return (char)(randomPosition.Next(32, 255));
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = baseColor;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);

            while (true)
            {
                Counter++;
                ColumnUpdate(width, height, y);

                if (Counter > (3 * flowspeed))
                {
                    Counter = 0;
                }
            }
        }

        public static int YPositionFields(int yPosition, int height)
        {
            if (yPosition < 0) return yPosition + height;
            else if (yPosition < height) return yPosition;
            else return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];

            Console.Clear();

            for (int x = 0; x < width; ++x)
            {
                y[x] = randomPosition.Next(height);
            }
        }

        private static void ColumnUpdate(int width, int height, int[] y)
        {
            int x;

            if (Counter < flowspeed)
            {
                for (x = 0; x < width; ++x)
                {
                    if (x % 10 == 1) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiCharacters);

                    if (x % 10 == 9) Console.ForegroundColor = fadedColor;
                    else Console.ForegroundColor = baseColor;

                    int temp = y[x] - 2;

                    Console.SetCursorPosition(x, YPositionFields(temp, height));
                    Console.Write(AsciiCharacters);

                    int temp1 = y[x] - 20;

                    Console.SetCursorPosition(x, YPositionFields(temp1, height));
                    Console.Write(' ');

                    y[x] = YPositionFields(y[x] + 1, height);
                }

                Console.SetCursorPosition(width / 2, height / 2);
                Console.Write(endText);
            }
            //else if (Counter > flowspeed && Counter < fastFlow)
            //{
            //    for (x = 0; x < width; ++x)
            //    {
            //        Console.SetCursorPosition(x, y[x]);

            //        if (x % 10 == 9) Console.ForegroundColor = fadedColor;
            //        else Console.ForegroundColor = baseColor;

            //        Console.Write(AsciiCharacters);

            //        y[x] = YPositionFields(y[x] + 1, height);
            //    }
            //}
            //else if (Counter > fastFlow)
            //{
            //    for (x = 0; x < width; ++x)
            //    {
            //        Console.SetCursorPosition(x, y[x]);
            //        Console.Write(' ');

            //        int temp1 = y[x] - 20;

            //        Console.SetCursorPosition(x, YPositionFields(temp1, height));
            //        Console.Write(' ');

            //        if (Counter > fastFlow && Counter < textFlow)
            //        {
            //            if (x % 10 == 9) Console.ForegroundColor = fadedColor;
            //            else Console.ForegroundColor = baseColor;

            //            int temp = y[x] - 2;

            //            Console.SetCursorPosition(x, YPositionFields(temp, height));
            //            Console.Write(AsciiCharacters);
            //        }

            //        Console.SetCursorPosition(width / 2, height / 2);
            //        Console.Write(endText);

            //        y[x] = YPositionFields(y[x] + 1, height);
            //    }
            //}
        }

    }
}
