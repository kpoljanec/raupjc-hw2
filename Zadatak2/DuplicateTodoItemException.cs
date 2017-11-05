using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(Guid id)
        {
            Console.WriteLine(string.Format("duplicate id : {0}", id));
        }
    }
}
