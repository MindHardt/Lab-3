using System;
using System.Data.SqlTypes;
using System.Runtime.InteropServices.ComTypes;

namespace Lab3._1_FuncSheet_
{
    class Program
    {
        static bool err = true;
        static string x1raw;
        static string xdraw;
        static string xnraw;
        static double x1;
        static double xd;
        static double xn;
        static string y;
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую, пользователь.");
            while (err == true)
            {
                Console.WriteLine("Введите, пожалуйста, начальное значение.");
                x1raw = Console.ReadLine();
                x1raw = x1raw.Replace(",", ".");
                Console.WriteLine("Введите, пожалуйста, шаг построения.");
                xdraw = Console.ReadLine();
                xdraw = xdraw.Replace(",", ".");
                Console.WriteLine("Введите, пожалуйста, максимальное значение.");
                xnraw = Console.ReadLine();
                xnraw = xnraw.Replace(",", ".");
                double number;
                if (double.TryParse(x1raw, out number) & double.TryParse(xdraw, out number) & double.TryParse(xnraw, out number)) { err = false; };
                if (err == false)
                {
                    x1 = double.Parse(x1raw);
                    xd = double.Parse(xdraw);
                    xn = double.Parse(xnraw);
                    if (((x1 > xn) & (xd > 0)) | ((x1 < xn) & (xd < 0)) | (xd == 0)) { err = true; };
                }
                if (err == true) { Console.WriteLine("В ваших данных ошибка. Повторите ввод."); }
            }
            Build();
        }
        static void Build()
        {
            int maxlengthx = 0;
            int maxlengthy = 0;
            double ysnum;
            int i = 0;
            string xs;
            string ys;
            double x = x1;
            while (x <= xn)
            {
                xs = Convert.ToString(x);
                if (maxlengthx < (xs.Length)) { maxlengthx = xs.Length; }
                ys = Formula(x);
                ysnum = Convert.ToDouble(ys);
                if (maxlengthy < (ys.Length)) { maxlengthy = ys.Length; }
                x = x + xd;
                i++;
            }
            Console.WriteLine("Ваша таблица значений:");
            Console.Write("|");
            for (int l = 1; l <= maxlengthx; l++) { Console.Write("-"); };
            Console.Write("|");
            for (int l = 1; l <= maxlengthy; l++) { Console.Write("-"); };
            Console.Write("|");
            Console.WriteLine();
            Console.Write("|");
            for (int l = 1; l <= ((maxlengthx - (maxlengthx % 2)) / 2); l++) { Console.Write(" "); };
            Console.Write("X");
            for (int l = 1; l <= (((maxlengthx - 1) - ((maxlengthx - 1) % 2)) / 2); l++) { Console.Write(" "); };
            Console.Write("|");
            for (int l = 1; l <= ((maxlengthy - (maxlengthy % 2)) / 2); l++) { Console.Write(" "); };
            Console.Write("Y");
            for (int l = 1; l <= (((maxlengthy - 1) - ((maxlengthy - 1) % 2)) / 2); l++) { Console.Write(" "); };
            Console.Write("|");
            Console.WriteLine();
            Console.Write("|");
            for (int l = 1; l <= maxlengthx; l++) { Console.Write("-"); };
            Console.Write("|");
            for (int l = 1; l <= maxlengthy; l++) { Console.Write("-"); };
            Console.Write("|");
            Console.WriteLine();
            x = x1;
            for (int j = 1; j <=i; j++)
            {
                xs = Convert.ToString(x);
                Console.Write("|");
                while (xs.Length < maxlengthx)
                {
                    xs = xs + " ";
                }
                Console.Write($"{xs}|");
                ys = Formula(x);
                while (ys.Length < maxlengthy)
                {
                    ys = ys + " ";
                }
                Console.WriteLine($"{ys}|");
                x = x + xd;

            }
            Console.Write("|");
            for (int l = 1; l <= maxlengthx; l++) { Console.Write("-"); };
            Console.Write("|");
            for (int l = 1; l <= maxlengthy; l++) { Console.Write("-"); };
            Console.Write("|");

        }
        static string Formula(double x)
        {
            try
            {
                // !!! ЗДЕСЬ ВВОДИТСЯ ФОРМУЛА И ПРОИСХОДИТ ВОЛШЕБСТВО!
                y = Convert.ToString(1 / (x * x));
                // !!! ЗДЕСЬ ВВОДИТСЯ ФОРМУЛА И ПРОИСХОДИТ ВОЛШЕБСТВО!
            }
            catch
            {
                y = "N/A";
            }
            return (y);
        }
    }
}
