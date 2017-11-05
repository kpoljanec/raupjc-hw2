using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int position;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
            position = -1;
        }

        public X Current
        {
            get
            {
                try
                {
                    return genericList.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            position++;
            return (position < genericList.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
