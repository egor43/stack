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
    public class MyStack<T> :LinearList<T> where T : struct
    {
        #region Polya
        private string[] listviev;
        #endregion

        #region Svoistva
        #endregion

        #region Konstryctory
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
            AddBack(value);
        }

        /// <summary>
        /// Удаляет и возвращает элемент из вершины стека
        /// </summary>
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
                for(; this.Length>0;)
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
        public new string  Print()
        {
            if ((this.Head != null) && (this.Length > 0))
            {
                string result="";
                int OldLength = this.Length;
                LinearList<T>.Element OldHead = this.Head;
                for (int i = 0; this.Length > 0; i++)
                {
                    result=result+this.Pop().ToString()+" ";
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
