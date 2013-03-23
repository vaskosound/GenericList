using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<T> // Задача 5
        where T : IComparable<T>
    {
        const int capacity = 4;
        private T[] elements;
        private int count;
        public int Size { get; private set; }

        public GenericList(int size)
        {
            this.elements = new T[this.Size];
        }

        public GenericList()           
        {
            this.Size = capacity;
            this.elements = new T[this.Size];
        }

        public T[] Element
        {
            get { return this.elements; }
            set { this.elements = value; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            if (this.count >= elements.Length)
            {
               AutoIncreaseCapcity();
            }
            this.elements[this.count] = element;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index > count || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }
                return this.elements[index];
            }
        }

        public void Remove(int index)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
            for (int i = index; i < count; i++)
            {
                elements[i] = elements[i + 1];
            }
            count--;
        }

        public void Insert(T element, int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
            count++;
            if (this.count > elements.Length)
            {
                AutoIncreaseCapcity();
            }
            for (int i = this.count - 1; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }
            elements[index] = element;
        }

        public void FindElement(T element)
        {
            bool isFind = false;
            for (int i = 0; i < this.count; i++)
            {
                if (elements[i].CompareTo(element) == 0)
                {
                    isFind = true;
                    Console.WriteLine("Element {1} is at position {0}", i, element);
                }
            }
            if (!isFind)
            {
                Console.WriteLine("Element {0} is not in the list!", element);
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.Size = capacity;
            this.elements = new T[capacity];
        }

        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                list.Append(elements[i]);
                if (i < this.count - 1)
                {
                    list.Append(", ");
                }
            }
            return list.ToString();
        }

        public void AutoIncreaseCapcity() // Задча 6
        {
            if (this.count >= this.Size)
            {
                this.Size *= 2;
                T[] tempList = (T[])elements.Clone();
                elements = new T[this.Size];
                for (int i = 0; i < tempList.Length; i++)
                {
                    elements[i] = tempList[i];
                }
            }
        }
        // Задача 7
        public T Min<T>() where T : IComparable<T>
        {
            dynamic min = elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (elements[i].CompareTo(min) < 0)
                {
                    min = elements[i];
                }
            }
            return min;
        }

        public T Max<T>() where T : IComparable<T>
        {
            dynamic max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].CompareTo(max) > 0)
                {
                    max = elements[i];
                }
            }
            return max;
        }
    }
}

