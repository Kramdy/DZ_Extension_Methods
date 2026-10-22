using System;
using System.Text;

namespace DZ_Extension_Methods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 — количество слов в строке");
                Console.WriteLine("3 — длина последнего слова");
                Console.WriteLine("4 — проверка скобок");
                Console.WriteLine("5 — фильтрация массива");
                Console.WriteLine("0 — выход");
                Console.Write("Выберите задание: ");
                switch (Console.ReadLine())
                {
                    case "1": TestWordCount(); break;
                    case "3": TestLastWordLength(); break;
                    case "4": TestBrackets(); break;
                    case "5": TestArrayFilter(); break;
                    case "0": return;
                    default: Console.WriteLine("Введите число 0, 1, 3, 4 или 5."); break;
                }
            }
        }

        // Задание 1
        // Создайте метод расширение (extension method) для подсчёта количества слов
        // в строке. Напишите код для тестирования метода.
        private static void TestWordCount()
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            Console.WriteLine("Количество слов: " + text.CountWords());
        }

        // Задание 3
        // Создайте метод расширение (extension method) для подсчёта длины последнего
        // слова в строке. Напишите код для тестирования метода.
        private static void TestLastWordLength()
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            Console.WriteLine("Длина последнего слова: " + text.LastWordLength());
        }

        // Задание 4
        // Создайте метод расширение (extension method) для проверки валидности
        // расставления скобок в строке. В строке могут содержаться такие скобки:
        // (, ), {, }, [, ]. Открывающиеся скобки должны закрываться скобками того же
        // типа и в правильном порядке. Например: {}[], (()), [{}] — валидные строки;
        // [}, [[{]}] — невалидные строки. Напишите код для тестирования метода.
        private static void TestBrackets()
        {
            Console.Write("Введите строку со скобками: ");
            string text = Console.ReadLine();
            Console.WriteLine(text.BracketsAreValid() ? "Строка валидна." : "Строка невалидна.");
        }

        // Задание 5
        // Создайте метод расширение для фильтрации элементов массива целых на основании
        // переданного аргумента (предикат для определения условия). Метод возвращает
        // новый, созданный массив после фильтрации. Например, в качестве условия может
        // быть предикат для проверки на чётность или нечётность элементов массива.
        private static void TestArrayFilter()
        {
            try
            {
                Console.Write("Введите целые числа через пробел: ");
                string[] text = Console.ReadLine().Split(' ');
                int[] numbers = new int[text.Length];
                for (int i = 0; i < text.Length; i++) numbers[i] = Convert.ToInt32(text[i]);
                Console.Write("1 — чётные, 2 — нечётные: ");
                string choice = Console.ReadLine();
                Predicate<int> condition = choice == "1" ? new Predicate<int>(IsEven) : new Predicate<int>(IsOdd);
                int[] result = numbers.Filter(condition);
                Console.Write("Результат: ");
                for (int i = 0; i < result.Length; i++) Console.Write(result[i] + " ");
                Console.WriteLine();
            }
            catch (Exception) { Console.WriteLine("Введите корректные данные."); }
        }
        private static bool IsEven(int number) { return number % 2 == 0; }
        private static bool IsOdd(int number) { return number % 2 != 0; }
    }
}
