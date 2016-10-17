using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStack;
using Linear_List;

namespace ConsoleTestMyStack
{
    class Program
    {
        private static int SelectionAction()
        {
            int result = -1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Push (добавить в вершину стека)");
                Console.WriteLine("2 - Pop (вернуть и удалить элемент из вершины)");
                Console.WriteLine("3 - Peek (вернуть элемент из вершины (без удаления))");
                Console.WriteLine("4 - Contains (проверить наличие элемента в стеке)");
                Console.WriteLine("5 - Print  (распечатать список)");
                Console.WriteLine("6 - Очистить список");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("0 - Выход из программы");
                if (Int32.TryParse(Console.ReadLine(), out result))
                {
                    if ((result > -1) && (result < 7))
                    {
                        return result;
                    }
                    Console.WriteLine("Действие с таким номером не найдено.");
                    System.Threading.Thread.Sleep(800);
                }
            }
        }

        private static void ExecutionAction(int IDaction, MyStack<int> mystack)
        {
            Console.Clear();
            int value;
            switch (IDaction)
            {
                case 1:
                    {
                        while (true)
                        {
                            Console.WriteLine("Push");
                            Console.WriteLine("Введите значение для добавления:");
                            if (Int32.TryParse(Console.ReadLine(), out value))
                            {
                                mystack.Push(value);
                                Console.WriteLine("Значение добавлено.");
                                System.Threading.Thread.Sleep(800);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введено неверное значение.");
                                System.Threading.Thread.Sleep(800);
                                Console.Clear();
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        while (true)
                        {
                            Console.WriteLine("Pop");
                            if (mystack.Length>0)
                            {
                                Console.WriteLine("Возвращенное значение: {0}", mystack.Pop());
                                Console.WriteLine("Для продолжения нажмите любую клавишу");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Стек пуст.");
                                System.Threading.Thread.Sleep(800);
                                Console.Clear();
                                
                            }
                            break;
                        }
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вы уверены, что хотите выйти?");
                        Console.WriteLine("1- ДА / 2 - НЕТ");
                        int answer = -1;
                        if (Int32.TryParse(Console.ReadLine(), out answer))
                        {
                            if (answer == 1) Environment.Exit(0);
                        }
                        break;
                    }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Stack v:1.0");
            System.Threading.Thread.Sleep(1000);
            MyStack<int> mystack = new MyStack<int>();
            while (true)
            {
                ExecutionAction(SelectionAction(), mystack);
            }

            #region Тестовый код
            //MyStack<double> ms = new MyStack<double>();
            //ms.Push(1);
            //ms.Push(2);
            //ms.Push(3);
            //ms.Push(4);
            //ms.Push(5);
            //ms.Push(6);
            //try
            //{
            //    Console.WriteLine(ms.Pop());
            //    Console.WriteLine(ms.Peek());
            //    Console.WriteLine(ms.Contains(6));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //Console.WriteLine(ms.Print());
            //Console.WriteLine(ms.Count);
            //Console.ReadLine();
            #endregion
        }
    }
}
