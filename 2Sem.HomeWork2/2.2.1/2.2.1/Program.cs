using System;

namespace _2._2._1
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Если вы хотите добавить элемент в список (Число, Позиция числа), введите 1");
            Console.WriteLine("Если вы хотите удалить элемент из списка (Позиция числа), введите 2");
            Console.WriteLine("Если вы хотите узнать размер списка, введите 3");
            Console.WriteLine("Если вы хотите установить значение элемента по позиции, введите 4");
            Console.WriteLine("Если вы хотите вывести список, введите 5");
            Console.WriteLine("Если вы хотите выйти, введите 0 : ");
            var list = new List();
            while (true)
            {
                Console.Write("Команда : ");
                int command = int.Parse(Console.ReadLine());

                if (command == 1)
                {
                    Console.Write("Введите элемент списка : ");
                    int value = int.Parse(Console.ReadLine());
                    Console.Write("Введите позицию элемента в списке : ");
                    int position = int.Parse(Console.ReadLine());
                    list.Add(value, position);
                }

                if (command == 2)
                {
                    Console.Write("Введите позицию элемента, который вы хотите удалить : ");
                    int position = int.Parse(Console.ReadLine());
                    list.Remove(position);
                }

                if (command == 3)
                {
                    Console.Write("Размер списка : ");
                    Console.WriteLine(list.GetSize());
                }

                if (command == 4)
                {
                    Console.Write("Введите позицию элемента : ");
                    int position = int.Parse(Console.ReadLine());
                    int value = list.GetElement(position);
                    if (value != -1)
                    {
                        Console.Write("Ваш элемент : ");
                        Console.WriteLine(value);
                    }
                }

                if (command == 5)
                {
                    if (list.GetSize() == 0)
                    {
                        Console.WriteLine("Ваш список пуст");
                    }
                    else
                    {
                        Console.Write("Ваш список : ");
                        list.OutputList();
                    }
                }
                if (command == 0)
                {
                    break;
                }
            }
        }
    }
}
