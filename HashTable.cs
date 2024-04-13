using Lab_10_lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_12_OOP
{
    public class HashTable<T> : ICloneable, IEnumerable<T>, ICollection<T>
    {

        public HElement<T>[] table;
        private int size;
        private int count;
        
        public int Size
        {
            get => size;

            set
            {
                if (value < 0)
                    throw new Exception("Ошибка, размер коллекции не может быть меньше 0");
                else
                    size = value;
            }
        }

        public int Count => count;

        public HashTable()
        {
            Size = 0;
            table = new HElement<T>[Size];
        }

        public HashTable(int size)
        {
            Size = size;
            table = new HElement<T>[Size];
        }

        public HashTable(HashTable<T> c)
        {
            this.Size = table.Length;
            for (int i = 0; i < Size; i++)
            {
                this.table[i] = c.table[i].Clone()
            }
            
        }

        public bool IsReadOnly => false;

        public int GetIndex(T value)
        {
            HElement<T> point = new HElement<T>(value);
            if (Size != 0)
                return Math.Abs(point.GetHashCode()) % Size;
            else return 0;
        }

        public void Add(T v)
        {
            HElement<T> point = new HElement<T>(v);
            int index = GetIndex(v);
            if (table[index] == null)
            {
                table[index] = point;
            }
            else
            {
                HElement<T> current = table[index];
                if (Equals(current, point))
                {
                    throw new ArgumentException("Элемент с таким ключом уже добавлен.");
                    return;
                }
                while (current.next != null)
                {
                    if (Equals(current, point))
                    {
                        throw new ArgumentException("Элемент с таким ключом уже добавлен.");
                        return;
                    }
                    current = current.next;
                }
                current.next = point;
            }
            count++;
        }

        public void Print()
        {
            if (table == null)
            {
                Console.WriteLine("Хеш-таблица пуста");
                return;
            }
            for (int i = 0; i < Size; i++)
            {
                if (table[i] == null) Console.WriteLine(i + ": ");
                else
                {
                    Console.Write(i + ": ");
                    HElement<T> ptr = table[i];
                    while (ptr != null)
                    {
                        Console.Write(ptr.ToString() + "   ");
                        ptr = ptr.next;
                    }
                    Console.WriteLine();
                }
            }
        }

        public bool Remove(T value)
        {
            HElement<T> point = new HElement<T>(value);
            int index = GetIndex(value);
            var node = table[index];
            HElement<T> prev = null;
            while (node != null)
            {
                if (Equals(point, node))
                {
                    if (prev != null)
                    {
                        prev.next = node.next;
                    }
                    else
                    {
                        table[index] = node.next;
                    }
                    return true;
                }
                prev = node;
                node = node.next;
            }
            return false;
        }

        public bool FindPoint(T value)
        {
            HElement<T> point = new HElement<T>(value);
            int index = Math.Abs(point.GetHashCode()) % Size;
            if (Equals(point, table[index])) return true;
            HElement<T> current = table[index];
            while (current != null)
            {
                if (HElement<T>.Equals(point, current))
                    return true;
                current = current.next;
            }
            return false;
        }

        public string FindPointKey(int key)
        {
            int index = Math.Abs(key) % Size;
            if (index < table.Length)
            {
                if (table[index].key == key)
                {
                    return "Элемент с ключом" + table[index].ToString();
                }
                HElement<T> current = table[index];
                while (current != null)
                {
                    if (current.key == key)
                        return "Элемент с ключом " + current.ToString();
                    current = current.next;
                }
            }
            return "Элемент с заданным ключом не найден";
        }

        public string RemoveKey(int key)
        {
            int index = Math.Abs(key) % Size;
            if (index < table.Length)
            {
                if (table[index].key == key)
                {
                    if (Remove(table[index].Value))
                        return "Элемент с заданным ключом удален";
                }
                HElement<T> current = table[index];
                while (current != null)
                {
                    if (current.key == key)
                    {
                        Remove(current.Value);
                        return "Элемент с заданным ключом удален";
                    }
                    current = current.next;
                }
            }
            return "Элемент с заданным ключом не найден";
        }

        public virtual HashTable<T> ShallowCopy()
        {
            return (HashTable<T>)MemberwiseClone();
        }

        public object Clone()
        {
            return new HashTable<T>(this);
            //return new HashTable<T>
            //{
            //    table = this.table,
            //    Size = this.Size
            //};
            //HashTable<T> cloneTable = new HashTable<T>();
            //foreach(var item in this)
            //{
            //    cloneTable.Add(item);
            //}
            //return cloneTable;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in table)
            {
                HElement<T> node = item;
                while (node != null)
                {
                    yield return node.Value;
                    node = node.next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            foreach(var item in table)
            {
                if (item != null)
                {
                    HElement<T> node = item;
                    while (node.next != null)
                    {
                        HElement<T> next = node.next;
                        node.Value = default;
                        node.next = null;
                        node = next;
                    }
                    node = null;
                }
            }
            count = 0;
            Size = 0;
        }

        public bool Contains(T item)
        {
            return FindPoint(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException("Количество элементов хеш-таблицы больше чем размер заданного массива.");
            }
            foreach (var pair in this)
            {
                array[arrayIndex++] = pair;
            }
        }

        private class HashTableEnumerator : IEnumerator<T>
        {
            private readonly HashTable<T> hashTable;
            private int tableIndex;
            private HElement<T> currentNode;

            public HashTableEnumerator(HashTable<T> hashTable)
            {
                this.hashTable = hashTable;
                Reset();
            }

            public T Current
            {
                get { return currentNode!.Value; }
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (currentNode != null && currentNode.next != null)
                {
                    currentNode = currentNode.next;
                    return true;
                }
                while (++tableIndex < hashTable.table.Length)
                {
                    if (hashTable.table[tableIndex] != null)
                    {
                        currentNode = hashTable.table[tableIndex];
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                tableIndex = -1;
                currentNode = null;
            }
        }
    }
}

