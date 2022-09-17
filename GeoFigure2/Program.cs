using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigure2
{
    abstract class GeoFigure
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public abstract decimal Square();
        public abstract decimal Perimeter();

    }
    class Rectangle : GeoFigure
    {
        private bool isCorrect = false;
        public Rectangle()
        {
            name = "ПРЯМОУГОЛЬНИК";
            do
            {
                try
                {
                    Console.Write("Введите длину: ");
                    Lengh = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Введите высоту: ");
                    Heigth = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine();
                    isCorrect = true;
                }
                catch
                {
                    Console.WriteLine("Неверный формат ввода! Попробуйте ещё раз: ");
                }
            }while(!isCorrect);
        }
        public override decimal Square()
        {
            decimal _square = this.lengh * this.heigth;
            return _square;
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.lengh + this.lengh + this.heigth + this.heigth;
            return _perimeter;
        }
        private decimal Lengh;

        public decimal lengh
        {
            get { return Lengh; }
            set { Lengh = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }
    class Rhomb : GeoFigure
    {
        public Rhomb()
        {
            bool isCorrect = false;
            name = "РОМБ";
            do
            {
                do
                {
                    try
                    {
                        Console.Write("Введите длину основания ромба: ");
                        Basis = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Введите высоту ромба: ");
                        Heigth = Convert.ToDecimal(Console.ReadLine());
                        isCorrect = true;
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода! Попробуйте ещё раз: ");
                    }
                } while (!isCorrect);
                if (Basis >= Heigth)
                {
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Высота не может быть больше основания!\nПопробуйте ещё раз:");
                    isCorrect = false;
                }
            } while (isCorrect != true);
            Console.WriteLine();
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.basis * 4;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal _square = this.basis * this.heigth;
            return _square;
        }
        private decimal Basis;

        public decimal basis
        {
            get { return Basis; }
            set { Basis = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }
    class createFigure
    {
        private GeoFigure _figure;
        private string answer;
        private string result;
        private bool isCorrect = false;
        private GeoFigure createAndWriteToArr()
        {
            do
            {
                Console.WriteLine("Какую фигуру хотите создать?:\n" +
                    "1 - ПРЯМОУГОЛЬНИК\n" +
                    "2 - РОМБ");
                Console.Write("Ввод -> ");
                answer = Console.ReadLine();
                Console.WriteLine();
                if (answer == "1")
                {
                    Rectangle myRectangle = new Rectangle();
                    _figure = myRectangle;
                    isCorrect = true;
                }
                else if (answer == "2")
                {
                    Rhomb mySquere = new Rhomb();
                    _figure = mySquere;
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Такого варианта нет, попробуйте ещё раз.\n");
                }
            }while(!isCorrect);
            return _figure;
        }
        public void PrintResult()
        {
            _figure = createAndWriteToArr();
            Console.WriteLine("{0}, площадь - {1} и периметр - {2} ", _figure.name, _figure.Square(), _figure.Perimeter());
            Console.WriteLine();
        }
        private string Result()
        {
            result = _figure.name + ", площадь - " + _figure.Square() + " и периметр - " + _figure.Perimeter() + ".\n";
            return result;
        }
        public void writeRequest()
        {
            string _fileName = "\\GeoFigure.txt";
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + _fileName;
            Console.WriteLine("Хотите ли записать результат работы программы в файл (Y/N): ");
            do
            {
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    result = Result();
                    StreamWriter Sw = new StreamWriter(_path, true);
                    Sw.Write(result);
                    Sw.Close();
                    Console.WriteLine("Запись была произведена в {0}", _path);
                    isCorrect = true;
                }
                else if (answer == "N" || answer == "n")
                {
                    Console.WriteLine("Завершите работу программы нажав \"Esc\".");
                    while (Console.ReadKey().Key != ConsoleKey.Escape) ;
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Нажмите Y или N: ");
                }
            } while (!isCorrect);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            createFigure CF = new createFigure();
            CF.PrintResult();
            CF.writeRequest();
        }
    }
}