using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linear_List;
using System.Reflection;

namespace MyStack
{
    public class MyStack<T> where T : struct
    {
        #region Polya
        private string[] listviev;
        private LinearList<T> linlist;
        #endregion

        #region Svoistva
        public int Count { get; private set; }
        #endregion

        #region Konstryctory
        public MyStack()
        {
            Count = 0;
            linlist = new LinearList<T>();
            listviev = null;
        }
        #endregion

        #region Private Metody

        #endregion

        #region Public Metody
        /// <summary>
        /// Добавляет элемент в вершину стека
        /// </summary>
        /// <param name="value">значение для добавления</param>
        public void Push(T value)
        {
            linlist.AddBack(value);
            Count++;
        }

        /// <summary>
        /// Удаляет и возвращает элемент из вершины стека
        /// </summary>
        /// <returns>элемент стека</returns>
        public T Pop()
        {
            if ((linlist != null) && (linlist.Length > 0))
            {
                string str = linlist.Print();
                listviev = str.Split(' ');
                if (typeof(T) == typeof(Int32))
                {
                    dynamic result = Convert.ToInt32(listviev[0]);
                    linlist.Delete(1);
                    Count--;
                    return (T)result;
                }
                if (typeof(T) == typeof(Double))
                {
                    dynamic result = Convert.ToDouble(listviev[0]);
                    linlist.Delete(1);
                    Count--;
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
            if ((linlist != null) && (linlist.Length > 0))
            {
                string str = linlist.Print();
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
            if ((linlist != null) && (linlist.Length > 0))
            {
                int count = this.Count;
                bool result = false;
                LinearList<T> lnold = new LinearList<T>();
                for(int i=0; linlist.Length>0;i++)
                {
                    if (value.ToString() == this.Peek().ToString()) result = true;
                    lnold.AddFront(this.Pop());
                }
                linlist = lnold;
                Count = count;
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
        public string Print()
        {
            if ((linlist != null) && (linlist.Length > 0))
            {
                int count = this.Count;
                string result="";
                LinearList<T> lnold = new LinearList<T>();
                for (int i = 0; linlist.Length > 0; i++)
                {
                    result=result+this.Peek().ToString()+" ";
                    lnold.AddFront(this.Pop());
                }
                linlist = lnold;
                Count = count;
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
