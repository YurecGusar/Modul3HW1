using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW1
{
    public class MyList<T> : IReadOnlyCollection<T>
    {
        private const int _defaultCapacity = 4;
        private int _counter = 0;
        private T[] _array;

        public MyList()
        {
            _array = new T[_defaultCapacity];
        }

        public int Count => _counter;

        public void Add(T value)
        {
            if (_array.Length == _counter)
            {
                Array.Resize(ref _array, _counter * 2);
            }

            _array[_counter++] = value;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            for (var index = 0; index < _array.Length; index++)
            {
                if (_array[index].Equals(item))
                {
                    RemoveAt(index);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            _array[index] = default(T);
            _counter--;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, comparer);
        }

        public void RemoveEmptiness()
        {
            var newList = new T[Count];
            var countForEmpty = 0;
            for (var i = 0; i < _array.Length; i++)
            {
                if (!_array[i].Equals(default(T)))
                {
                    newList[countForEmpty++] = _array[i];
                }
            }

            _array = newList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = 0; i < _array.Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < _array.Length; i++)
            {
                yield return _array[i];
            }
        }
    }
}
