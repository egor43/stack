using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linear_List;
using System.Reflection;

namespace MyStack
{
    /// <summary>
    /// Представляет стек открытого структурного типа.
    /// </summary>
    /// <typeparam name="T">указатель места заполнения (ограничение: struct)</typeparam>
    public class MyStack<T> : LinearList<T> where T : struct
    {
        #region Polya
        private string[] listviev;
        #endregion

        #region Svoistva
        #endregion

        #region Konstryctory
        #endregion

        #region Private Metody

        /// <summary>
        /// Проверка строки на наличие недопустимых символов
        /// </summary>
        /// <param name="inputstring">строковое представление выражения</param>
        /// <returns>true - если выражение не содержит недопустимые символы. false - если выражение содержит недопустимые символы.</returns>
        private bool ValidationInputString(string inputstring)
        {
            if (inputstring[inputstring.Length - 1] != '=') inputstring += "=";
            List<string> list = new List<string>();
            int countznak = 0;
            int countchisl = 0;
            string str = "";
            foreach (var v in inputstring)
            {
                switch (v)
                {
                    case ')':
                    case '(':
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '=':
                        {
                            countznak++;
                            list.Add(str);
                            str = "";
                            break;
                        }
                    default:
                        {
                            str += v;
                            break;
                        }
                }
            }
            foreach (var v in list)
            {
                double x = 0;
                if (Double.TryParse(v, out x))
                {
                    countchisl += v.Length;
                }
            }
            if (countchisl + countznak == inputstring.Length) return true;
            return false;
        }

        /// <summary>
        /// Представляет введенное выражение в виде обратной Польской нотации
        /// </summary>
        /// <param name="inputstring">строковое представление выражения</param>
        /// <returns>Возвращает лист, каждый элемент которого, соответствует элементу выражения в обратной Польской нотации</returns>
        private List<string> CreateListString(string inputstring)
        {
            Stack<char> stackcalc = new Stack<char>();
            string primer = inputstring;
            if (primer[primer.Length - 1] != '=') primer += "=";
            string countstr = "";
            List<string> list = new List<string>();
            foreach (var c in primer)
            {
                switch (c)
                {
                    case '(':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            stackcalc.Push(c);
                            break;
                        }
                    case ')':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            while (stackcalc.Count > 0)
                            {
                                if (stackcalc.Peek() == '(')
                                {
                                    stackcalc.Pop();
                                    break;
                                }
                                list.Add(stackcalc.Pop().ToString());
                            }
                            break;
                        }
                    case '+':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            while (stackcalc.Count > 0)
                            {
                                if (stackcalc.Peek() == '(')
                                {
                                    break;
                                }
                                list.Add(stackcalc.Pop().ToString());
                            }
                            stackcalc.Push(c);
                            break;
                        }
                    case '-':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            while (stackcalc.Count > 0)
                            {
                                if (stackcalc.Peek() == '(')
                                {
                                    break;
                                }
                                list.Add(stackcalc.Pop().ToString());
                            }
                            stackcalc.Push(c);
                            break;
                        }
                    case '*':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            if ((stackcalc.Count > 0) && ('/' == stackcalc.Peek()))
                            {
                                if ((stackcalc.Peek() == '(') || (stackcalc.Peek() == '+') || (stackcalc.Peek() == '-'))
                                {
                                    break;
                                }
                                list.Add(stackcalc.Pop().ToString());
                            }
                            stackcalc.Push(c);
                            break;
                        }
                    case '/':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            if ((stackcalc.Count > 0) && ('*' == stackcalc.Peek()))
                            {
                                if ((stackcalc.Peek() == '(') || (stackcalc.Peek() == '+') || (stackcalc.Peek() == '-'))
                                {
                                    break;
                                }
                                list.Add(stackcalc.Pop().ToString());
                            }
                            stackcalc.Push(c);
                            break;
                        }
                    case '=':
                        {
                            if (countstr != "") list.Add(countstr);
                            countstr = "";
                            while (stackcalc.Count > 0) list.Add(stackcalc.Pop().ToString());
                            break;
                        }
                    default:
                        {
                            countstr += c.ToString();
                            break;
                        }
                }
            }
            return list;
        }

        #endregion

        #region Public Metody

        /// <summary>
        /// Производит вычисление выражения на основе обратной Польской нотации
        /// </summary>
        /// <param name="str">строковое представление выражения</param>
        /// <returns>результат вычисления выражения</returns>
        public double Calculate(string str)
        {
            if (ValidationInputString(str))
            {
                List<string> list = CreateListString(str);
                double x1 = 0, x2 = 0;
                Stack<double> countstack = new Stack<double>();
                try
                {
                    foreach (var v in list)
                    {
                        if (Double.TryParse(v, out x1))
                        {
                            countstack.Push(x1);
                            continue;
                        }
                        if (v == "+")
                        {
                            x2 = countstack.Pop();
                            x1= countstack.Pop();
                            countstack.Push(x1 + x2);
                            continue;
                        }
                        if (v == "-")
                        {
                            x2 = countstack.Pop();
                            x1 = countstack.Pop();
                            countstack.Push(x1 - x2);
                            continue;
                        }
                        if (v == "*")
                        {
                            x2 = countstack.Pop();
                            x1 = countstack.Pop();
                            countstack.Push(x1 * x2);
                            continue;
                        }
                        if (v == "/")
                        {
                            x2 = countstack.Pop();
                            x1 = countstack.Pop();
                            countstack.Push(x1 / x2);
                            continue;
                        }
                    }
                    return countstack.Pop();
                }
                catch (InvalidOperationException)
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Добавляет элемент в вершину стека
        /// </summary>
        /// <param name="value">значение для добавления</param>
        public void Push(T value)
        {
            AddBack(value);
        }

        /// <summary>
        /// Удаляет и возвращает элемент из вершины стека
        /// </summary> (1+2)*3-2  12+3*2-
        /// <returns>элемент стека</returns>
        public T Pop()
        {
            if ((this.Head != null) && (this.Length > 0))
            {
                string str = base.Print();
                listviev = str.Split(' ');
                if (typeof(T) == typeof(Int32))
                {
                    dynamic result = Convert.ToInt32(listviev[0]);
                    this.Delete(1);
                    return (T)result;
                }
                if (typeof(T) == typeof(Double))
                {
                    dynamic result = Convert.ToDouble(listviev[0]);
                    this.Delete(1);
                    return (T)result;
                }
                throw new InvalidOperationException("Неверный тип");
            }
            else
            {
                throw new InvalidOperationException("Стек пуст");
            }
        }

        /// <summary>
        /// Возвращает элемент из вершины стека
        /// </summary>
        /// <returns>элемент стека</returns>
        public T Peek()
        {
            if ((this.Head != null) && (this.Length > 0))
            {
                string str = base.Print();
                listviev = str.Split(' ');
                if (typeof(T) == typeof(Int32))
                {

                    dynamic result = Convert.ToInt32(listviev[0]);
                    return (T)result;
                }
                if (typeof(T) == typeof(Double))
                {
                    dynamic result = Convert.ToDouble(listviev[0]);
                    return (T)result;
                }
                throw new InvalidOperationException("Неверный тип");
            }
            else
            {
                throw new InvalidOperationException("Стек пуст");
            }
        }

        /// <summary>
        /// Проверяет наличие элемента в стеке
        /// </summary>
        /// <param name="value">значение для поиска</param>
        /// <returns>true - если элемент найден. false - если элемент не найден</returns>
        public bool Contains(T value)
        {
            if ((this.Head != null) && (this.Length > 0))
            {
                bool result = false;
                int OldLength = this.Length;
                LinearList<T>.Element OldHead = this.Head;
                for (; this.Length > 0;)
                {
                    if (value.ToString() == this.Pop().ToString()) result = true;
                }
                this.Head = OldHead;
                this.Length = OldLength;
                return result;
            }
            else
            {
                throw new InvalidOperationException("Стек пуст");
            }
        }

        /// <summary>
        /// Печать стека
        /// </summary>
        /// <returns>строковое представление стека</returns>
        public new string Print()
        {
            if ((this.Head != null) && (this.Length > 0))
            {
                string result = "";
                int OldLength = this.Length;
                LinearList<T>.Element OldHead = this.Head;
                for (int i = 0; this.Length > 0; i++)
                {
                    result = result + this.Pop().ToString() + " ";
                }
                this.Head = OldHead;
                this.Length = OldLength;
                return result;
            }
            else
            {
                throw new InvalidOperationException("Стек пуст");
            }
        }
        #endregion
    }
}
