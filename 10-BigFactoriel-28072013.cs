using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class BigFactoriel
    {
        static void Main()
        {
            Console.Write("Enter N to Calculate N!: ");
            int n = int.Parse(Console.ReadLine());
            List<int> result = new List<int>();
            int[] temp1 = { 1 };
            for (int i = 1; i <= n; i++)
            {
                int[] temp2 = ToCharArray(i);
                result = MultiplyArrays(temp2, temp1);
                temp1 = result.ToArray();
                Console.WriteLine(string.Join("", result));
            }
        }

        // Метод с който събираме получените списъци от първоначалното умножение
        static List<int> AddingLists(List<int> shorter, List<int> longer)
        {
            List<int> result = new List<int>();
            shorter.Reverse();
            longer.Reverse();
            int carry = 0;

            for (int i = 0; i < shorter.Count; i++)
            {
                result.Add((shorter[i] + longer[i] + carry) % 10);
                carry = ((shorter[i] + longer[i] + carry) / 10);
            }

            for (int i = shorter.Count; i < longer.Count; i++)
            {
                result.Add((longer[i] + carry) % 10);
                carry = (longer[i] + carry) / 10;
            }

            // Специален случай който покриваме ако стигнем края на longer и все още имаме carry ("1 на ум")
            if (carry > 0)
            {
                result.Add(carry);
            }
            result.Reverse();
            return result;
        }

        // Този метод умножава едно число от първия масив по всички числа от втория масив
        // Използва се в MultiplyArrays метода
        static List<int> SimpleMultiply(int[] array, int number)
        {
            List<int> product = new List<int>();
            int carry = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                product.Add((number * array[i] + carry) % 10);
                carry = (number * array[i]) / 10;
            }

            if (carry > 0)
            {
                product.Add(carry);
            }

            product.Reverse();
            return product;
        }

        // Тук имплементираме стандартното умножение, както сме го учили в училище.
        // ВЖ. “karatsuba multiplication“ за по-добро решение.
        static List<int> MultiplyArrays(int[] first, int[] second)
        {
            List<int> result = new List<int>();
            List<List<int>> temp = new List<List<int>>();
            for (int i = first.Length - 1, listNum = 0; i >= 0; i--, listNum++)
            {
                temp.Add(SimpleMultiply(second, first[i]));
                for (int shift = first.Length - 1; shift > i; shift--)
                {
                    temp[listNum].Add(0);
                }
            }
            if (temp.Count > 1)
            {
                for (int i = 0; i < temp.Count - 1; i++)
                {
                    result = AddingLists(temp[i], temp[i + 1]);
                    temp[i + 1] = result;
                }

                return result;
            }
            else
            {
                return temp[0];
            }
        }

        static int[] ToCharArray(int num)
        {
            string stringNum = num.ToString();
            int[] result = new int[stringNum.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = stringNum[i] - '0';
            }
            return result;
        }
    }
