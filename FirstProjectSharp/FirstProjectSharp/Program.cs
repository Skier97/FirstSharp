using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа решения шести задачей на С#!");
            Console.WriteLine("Введите число: ");
            Console.WriteLine("1 - Программа FiDo");
            Console.WriteLine("2 - Программа ReverseWord");
            Console.WriteLine("3 - Программа ReverseWords");
            Console.WriteLine("4 - Программа подсчета гласных");
            Console.WriteLine("5 - Программа вычисления уникальных чисел в массиве");
            Console.WriteLine("6 - Программа нахождения пересечения двух массивов");
            int val = int.Parse(Console.ReadLine());
            switch (val)
            {
                case 1:
                    Program.FiDo();
                    break;
                case 2:
                    Program.ReverseWord();
                    break;
                case 3:
                    Program.ReverseWords();
                    break;
                case 4:
                    Program.VowelCount();
                    break;
                case 5:
                    Program.UniqNumbers();
                    break;
                case 6:
                    Program.IntersecNumbers();
                    break;
                default:
                    Console.WriteLine("Ввели неверный номер!");
                    break;
            }
            Console.ReadKey();
        }
        public static void FiDo()
        {
            Console.WriteLine("Программа FiDo!");
            Console.Write("Введите число n: ");
            int n;
            try
            {
                n = int.Parse(Console.ReadLine());//чтение введенного числа n
                for (int i = 1; i <= n; i++)
                {
                    if ((i % 2 == 0) && (i % 3 == 0))//если число делится на 2 и на 3, то замена числа на FiDo
                    {
                        Console.WriteLine("FiDo");
                    }
                    else if (i % 2 == 0)//если число делится только на 2, то замена числа на Fi
                    {
                        Console.WriteLine("Fi");
                    }
                    else if (i % 3 == 0)//если число делится только на 3, то замена числа на Do
                    {
                        Console.WriteLine("Do");
                    }
                    else//иначе число остается неизменным
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка!!!");
            }
            Console.ReadKey();
        }
        public static void ReverseWord()
        {
            Console.WriteLine("Программа реверсирования слова!");
            Console.Write("Введите слово: ");
            string word;
            char[] newWord;
            string outWord;

            word = Console.ReadLine();
            newWord = word.ToCharArray();// представим строку в виде массива символов
            Array.Reverse(newWord);//функция реверсирования символов
            outWord = new string(newWord);//конвертация в строковый тип
            Console.Write("Перевернутое слово: ");
            Console.WriteLine(outWord);
            Console.ReadKey();
        }
        public static void ReverseWords()
        {
            Console.WriteLine("Программа реверсирования слов!");
            Console.Write("Введите предложение: ");
            string text;
            text = Console.ReadLine();
            string[] arr_word = text.Split(' ');//функция Split ищет пробелы, что является признаком конца подстроки. Итог - массив подстрок
            for (int i = arr_word.Length - 1; i >= 0; i--)
            {
                Console.Write(arr_word[i] + " ");
            }
            Console.WriteLine(" ");
            Console.ReadKey();
        }
        public static void VowelCount()
        {
            string text;
            int count = 0;
            char[] newText;
            // char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Программа подсчета гласных букв!");
            Console.Write("Введите текст: ");

            text = Console.ReadLine().ToLower();//для простоты делаем текст в нижнем регистре, чтобы не проверять и заглавные буквы
            newText = text.ToCharArray();//представим в виде набора символов
            for (int i = 0; i < newText.Length; i++)
            {
                if ((newText[i] == 'a') || (newText[i] == 'e') || (newText[i] == 'i') || (newText[i] == 'o') || (newText[i] == 'u'))//проверка на гласную букву
                {
                    count++;//думаю есть вариант получше сделать проверку :)
                }
            }
            Console.WriteLine("Количество гласных букв в тексте: " + count);
            Console.ReadKey();
        }
        public static void UniqNumbers()
        {
            Console.WriteLine("Программа пересчета массива с уникальными числами!");
            Console.Write("Введите размер массива: ");
            try
            {
                int size_arr = int.Parse(Console.ReadLine());
                int[] arr = new int[size_arr];
                for (int i = 0; i < size_arr; i++)
                {
                    Console.Write("Введите arr[" + i + "]: ");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                int[] newArr = arr.Distinct().ToArray();//функция удаления повторяющихся чисел в массиве
                Console.WriteLine("Полученный массив: ");
                for (int i = 0; i < newArr.Length; i++)
                {
                    Console.Write(newArr[i] + " ");
                }
                Console.WriteLine(" ");
            }
            catch
            {
                Console.WriteLine("Ошибка!!!");
            }

            Console.ReadKey();
        }
        public static void IntersecNumbers()
        {
            Console.WriteLine("Программа вывода пересечений массива!");
            Console.Write("Введите размер первого массива: ");
            try
            {
                int size_arr1 = int.Parse(Console.ReadLine());
                int[] arr1 = new int[size_arr1];
                for (int i = 0; i < size_arr1; i++)
                {
                    Console.Write("Введите arr1[" + i + "]: ");
                    arr1[i] = int.Parse(Console.ReadLine());
                }
                Console.Write("Введите размер второго массива: ");
                int size_arr2 = int.Parse(Console.ReadLine());
                int[] arr2 = new int[size_arr2];
                for (int i = 0; i < size_arr2; i++)
                {
                    Console.Write("Введите arr2[" + i + "]: ");
                    arr2[i] = int.Parse(Console.ReadLine());
                }
                List<int> newArr = new List<int> { };//список пересечений двух массивов (с возможными повторами)

                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])//если числа одинаковые, то добавляет в новый List
                        {
                            newArr.Add(arr2[j]);
                            break;
                        }
                    }
                }
                IEnumerable<int> distinctArr = newArr.Distinct();//удаление повторов из List
                Console.WriteLine("Повторяющиеся числа: ");
                foreach (int arr in distinctArr)
                {
                    Console.Write(arr + " ");
                }
                Console.WriteLine(" ");
            }
            catch
            {
                Console.WriteLine("Ошибка!!!");
            }
            Console.ReadKey();
        }
    }
}
