using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace SortedList_Library
{
    public class MySortedList<T> : ICollection<T>
    {
        private readonly List<T> _list;
        
        public event EventHandler<MySortedListEventArgs> SortedListEvent;
        protected virtual void SortedListEventMethod(MySortedListEventArgs e)
        {
            var temp = Volatile.Read(ref SortedListEvent);
            temp?.Invoke(this, e);
        }

        public MySortedList()
        {
            _list = new List<T>();
        }
        public void Add(T item)
        {
            int index = GetInsertIndex(item);
            _list.Insert(index, item);

            var args = new MySortedListEventArgs("Add", item.ToString());
            SortedListEventMethod(args);
            
        }
        public void Clear()
        {
            _list.Clear();

            var args = new MySortedListEventArgs("Clear", null);
            SortedListEventMethod(args);
            
        }
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex=0)
        {
            // _list.CopyTo(array, arrayIndex);
            foreach (var item in array)
            {
                var index = GetInsertIndex(item);
                _list.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            _list.Remove(item);
            
            var args = new MySortedListEventArgs("Remove", item.ToString());
            SortedListEventMethod(args);
            
            return true;

        }
        public int Count => _list.Count; 
        public bool IsReadOnly => false; 
        public T this[int index]
        {
            // get
            // {
            //     return _list[index];
            // }
            
            get
            {
                if (index >= _list.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index "+index+" is out of range.");
                }

                return _list[index];
            }
        
    }

        public int IndexOf(T item)
        {
            return _list.FindIndex(elem => elem.Equals(item));
        }
        public int GetInsertIndex(T item)
        {
            Comparer<T> comparer = Comparer<T>.Default; 
            
            if (_list.Count == 0) return 0;

            int left = 0;
            int right = _list.Count - 1;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (_list[middle].Equals(item)) return middle;
                if (comparer.Compare(_list[middle], item) > 0) right = middle - 1;
                else left = middle + 1;
            }

            if (comparer.Compare(_list[left], item) > 0) return left;
            return left + 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}

