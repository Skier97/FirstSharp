using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// В целом все хорошо. Хорошо что меню сделал, интерфейс приятный и в целом все чисто и аккуратно
        /// 
        /// Юзай разделения пустыми строками, так читается попроще. Между методами, классами, логическими блоками. Памяти это не занимает и на конечный код никак не влияет, но читается приятнее.
        /// 
        /// Комментарии это хорошо, но хороший комментарий должен описывать решение, Почему ты так сделал, а не подругому. 
        /// Старайся избегать коментариев типа "считываем строку из консоли" или "конвертируем массив в строку", это и так видно из кода
        /// 
        /// Если нет необходимости то старайся обьявлять переменные как можно ближе к месту использования, чем меньше область жизни переменной тем лучше? Наблюдается по всему коду, помни "обьявил и сразу используешь"
        /// Чем меньше строк кода тем проще читается код
        /// 
        /// Часть комментариев в коде
        /// </summary>
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
                    FiDo(); //Зачем пишешь Program?
                    break;
                case 2:
                    ReverseWord();
                    break;
                case 3:
                    ReverseWords();
                    break;
                case 4:
                    VowelCount();
                    break;
                case 5:
                    UniqNumbers();
                    break;
                case 6:
                    IntersecNumbers();
                    break;
                default:
                    Console.WriteLine("Ввели неверный номер!"); //+ Если юзаешь свитч то не забывай про default случай
                    break;
            }

            Console.ReadKey();
        }
        //не забывай разделять методы, лог блоки
        public static int CheckNumber()
        {
            while(true)
            {
                try
                {
                    int number  = int.Parse(Console.ReadLine());
                    return number;
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введите число еще раз!");
                }
            }
        }

        public static void FiDo()
        {
            Console.WriteLine("Программа FiDo!");
            Console.Write("Введите число n: ");

            //int n;   // в данном случае можно было прямо в Try обьявить int n = int.Parse(Console.ReadLine());
            int n = CheckNumber();
            for (int i = 1; i <= n; i++)
            {
                if ((i % 2 == 0) && (i % 3 == 0))   // Комментарий избыточен
                {
                    Console.WriteLine("FiDo");
                }
                else if (i % 2 == 0)   // Комментарий избыточен
                {
                    Console.WriteLine("Fi");
                }
                else if (i % 3 == 0)    // Комментарий избыточен
                {
                    Console.WriteLine("Do");
                }
                else//иначе число остается неизменным   // Комментарий избыточен
                {
                    Console.WriteLine(i);
                }
            }

            Console.ReadKey();
        }

        public static void ReverseWord()
        {
            Console.WriteLine("Программа реверсирования слова!");
            Console.Write("Введите слово: ");
            //string word; //Опять же, обьявляешь и сразу используешь
            char[] newWord;
            string outWord;

            string word = Console.ReadLine();
            newWord = word.ToCharArray();   // Комментарий избыточен
            Array.Reverse(newWord);    // Комментарий избыточен
            outWord = new string(newWord);//конвертация в строковый тип     // Комментарий избыточен
            Console.Write("Перевернутое слово: ");
            Console.WriteLine(outWord);
            Console.ReadKey();
        }

        public static void ReverseWords()
        {
            Console.WriteLine("Программа реверсирования слов!");
            Console.Write("Введите предложение: ");
            //string text;
            string text = Console.ReadLine();
            //Лучше string text = Console.ReadLine();

            text = string.Join(" ", text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            string[] arr_word = text.Split(' ');//функция Split ищет пробелы, что является признаком конца подстроки. Итог - массив подстрок    // Комментарий избыточен
            for (int i = arr_word.Length - 1; i >= 0; i--)
            {
                Console.Write(arr_word[i] + " ");
            }
            Console.WriteLine(" ");
            Console.ReadKey();
        }

        public static void VowelCount()
        {
            //string text; //Обьявил и сразу используешь
            int count = 0;
            char[] newText;
            //char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' }; //Вариант с обьявлением массива мне больше нравится
            Console.WriteLine("Программа подсчета гласных букв!");
            Console.Write("Введите текст: ");

            string text = Console.ReadLine().ToLower();//для простоты делаем текст в нижнем регистре, чтобы не проверять и заглавные буквы
            newText = text.ToCharArray();//представим в виде набора символов    // Комментарий избыточен //Шаг лишний, можешь перебирать символы строки прямо в строке text[i]

            for (int i = 0; i < newText.Length; i++)
            {
                /*
                if (vowels.Contains(text[i])) //Так можно проверять
                {
                    Console.WriteLine(text[i]); 
                }
                */
                if ((newText[i] == 'a') || (newText[i] == 'e') || (newText[i] == 'i') || (newText[i] == 'o') || (newText[i] == 'u'))//проверка на гласную букву    //Вариант с обьявлением массива мне больше нравится
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
            int size_arr = CheckNumber();
            int[] arr = new int[size_arr];
            for (int i = 0; i < size_arr; i++)
            {
                Console.Write("Введите arr[" + i + "]: ");
                arr[i] = CheckNumber();
            }

            int[] newArr = arr.Distinct().ToArray();//функция удаления повторяющихся чисел в массиве    // Комментарий избыточен
            Console.WriteLine("Полученный массив: ");
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write(newArr[i] + " ");
            }
            Console.WriteLine(" ");
            Console.ReadKey();
        }

        public static void IntersecNumbers()
        {
            Console.WriteLine("Программа вывода пересечений массива!");
            Console.Write("Введите размер первого массива: ");
            int size_arr1 = CheckNumber();
            int[] arr1 = new int[size_arr1];

            for (int i = 0; i < size_arr1; i++)
            {
                Console.Write("Введите arr1[" + i + "]: ");
                arr1[i] = CheckNumber();
            }

            Console.Write("Введите размер второго массива: ");
            int size_arr2 = CheckNumber();
            int[] arr2 = new int[size_arr2];

            for (int i = 0; i < size_arr2; i++)
            {
                Console.Write("Введите arr2[" + i + "]: ");
                arr2[i] = CheckNumber();
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
                    /* Можно было сделать так и тогда дальше не нужно доп вычисление уникальных
                    if (arr1[i] == arr2[j] && !newArr.Contains(arr1[i]))//если числа одинаковые, то добавляет в новый List
                    {
                        newArr.Add(arr2[j]);
                        break;
                    }
                     */
                }
            }


            IEnumerable<int> distinctArr = newArr.Distinct();//удаление повторов из List 
            Console.WriteLine("Повторяющиеся числа: ");

            foreach (int arr in distinctArr)
            {
                Console.Write(arr + " ");
            }
            Console.WriteLine(" ");

            Console.ReadKey();
        }
    }
}
