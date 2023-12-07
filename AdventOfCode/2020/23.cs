using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2020
{
    class _23
    {

        public void RunA()
        {
            var list = input.Select(c => int.Parse(c.ToString())).ToList();

            
            for(int i = 0; i < 100; ++i)
            {
                var current = list[0];
                var take = list.Skip(1).Take(3).ToList();
                list = list.Skip(4).Take(5).Prepend(current).ToList();
                var next = current - 1;
                while(true)
                {
                    var index = list.FindIndex(item => item == next);
                    if ( index > 0 )
                    {
                        list.InsertRange(index + 1, take);
                        break;
                    }

                    next = ((next - 1) + 10) % 10;
                }

                list = list.Skip(1).Append(list.First()).ToList();
            }

            while(list[0] != 1)
            {
                list = list.Skip(1).Append(list.First()).ToList();
            }

            Console.WriteLine(string.Join("", list.Skip(1).Select(i => i.ToString())));
        }

        public class OrderedSet<T> : ICollection<T>
        {
            private readonly IDictionary<T, LinkedListNode<T>> m_Dictionary;
            private readonly LinkedList<T> m_LinkedList;

            public OrderedSet()
                : this(EqualityComparer<T>.Default)
            {
            }

            public OrderedSet(IEnumerable<T> list)
                : this(EqualityComparer<T>.Default)
            {
                foreach (var i in list)
                {
                    Add(i);
                }
            }

            public OrderedSet(IEqualityComparer<T> comparer)
            {
                m_Dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
                m_LinkedList = new LinkedList<T>();
            }

            public int Count
            {
                get { return m_Dictionary.Count; }
            }

            public virtual bool IsReadOnly
            {
                get { return m_Dictionary.IsReadOnly; }
            }

            void ICollection<T>.Add(T item)
            {
                Add(item);
            }

            public bool Add(T item)
            {
                if (m_Dictionary.ContainsKey(item)) return false;
                LinkedListNode<T> node = m_LinkedList.AddLast(item);
                m_Dictionary.Add(item, node);
                return true;
            }

            public void Clear()
            {
                m_LinkedList.Clear();
                m_Dictionary.Clear();
            }

            public bool Remove(T item)
            {
                LinkedListNode<T> node;
                bool found = m_Dictionary.TryGetValue(item, out node);
                if (!found) return false;
                m_Dictionary.Remove(item);
                m_LinkedList.Remove(node);
                return true;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return m_LinkedList.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public bool Contains(T item)
            {
                return m_Dictionary.ContainsKey(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                m_LinkedList.CopyTo(array, arrayIndex);
            }

            public List<T> Take()
            {
                var take = m_LinkedList.Skip(1).Take(3).ToList();
                Remove(take[0]);
                Remove(take[1]);
                Remove(take[2]);
                return take;
            }

            public void InsertAfter(T value, IEnumerable<T> toInsert)
            {
                var node = m_Dictionary[value];

                foreach (var v in toInsert)
                {
                    node = m_LinkedList.AddAfter(node, v);
                    m_Dictionary[v] = node;
                }
            }

            public void Rotate()
            {
                var first = this.First();
                Remove(first);
                Add(first);
            }
        }


        public void RunB()
        {
            //input = "389125467";

            var list = new OrderedSet<int>(input.Select(c => int.Parse(c.ToString())).Concat(Enumerable.Range(10, 999991)));


            for (int i = 0; i < 10000000; ++i)
            {
                var current = list.First();
                var take = list.Take();
                var next = current - 1;
                while (true)
                {
                    if ( list.Contains(next))
                    {
                        list.InsertAfter(next, take);
                        break;
                    }

                    next = ((next - 1) + 1000001) % 1000001;
                }

                list.Rotate();
            }

            while (list.First() != 1)
            {
                list.Rotate();
            }

            Console.WriteLine(list.ElementAt(1));
            Console.WriteLine(list.ElementAt(2));
            Console.WriteLine(((Int64)list.ElementAt(1)) * list.ElementAt(2));
        }

        private string input = @"963275481";
    }
}
