using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _counter;

        public GenericList()
        {
            _internalStorage = new X[4];
            _counter = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new X[initialSize];
                _counter = 0;
            }
            else
            {
                throw new ArgumentException("Initial size must be greater than zero!");
            }
        }

        public void Add(X item)
        {
            if (_counter == _internalStorage.Length - 1)
            {
                X[] tmp = _internalStorage;
                _internalStorage = new X[_internalStorage.Length * 2];
                Array.Copy(tmp, _internalStorage, tmp.Length);
            }
            _internalStorage[_counter++] = item;
        }

        public bool RemoveAt(int index)
        {
            if (index > _counter)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                _internalStorage[index] = default(X);
                for (int i = index; i < _counter; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _counter--;
                return true;
            }
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _counter; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _counter)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _counter; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return _counter;
            }
        }

        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            _counter = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _counter; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
