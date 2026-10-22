using System;

namespace DZ_Extension_Methods
{
    internal static class ExtensionMethods
    {
        public static int CountWords(this string text)
        {
            if (text == null || text == "") return 0;
            int count = 0;
            bool insideWord = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ' && !insideWord) { count++; insideWord = true; }
                if (text[i] == ' ') insideWord = false;
            }
            return count;
        }
        public static int LastWordLength(this string text)
        {
            if (text == null || text == "") return 0;
            int index = text.Length - 1;
            while (index >= 0 && text[index] == ' ') index--;
            int length = 0;
            while (index >= 0 && text[index] != ' ') { length++; index--; }
            return length;
        }
        public static bool BracketsAreValid(this string text)
        {
            char[] stack = new char[text.Length];
            int top = -1;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (symbol == '(' || symbol == '{' || symbol == '[') stack[++top] = symbol;
                if (symbol == ')' || symbol == '}' || symbol == ']')
                {
                    if (top == -1) return false;
                    char open = stack[top--];
                    if ((symbol == ')' && open != '(') || (symbol == '}' && open != '{') || (symbol == ']' && open != '[')) return false;
                }
            }
            return top == -1;
        }
        public static int[] Filter(this int[] numbers, Predicate<int> condition)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++) if (condition(numbers[i])) count++;
            int[] result = new int[count];
            int index = 0;
            for (int i = 0; i < numbers.Length; i++) if (condition(numbers[i])) result[index++] = numbers[i];
            return result;
        }
    }
}
