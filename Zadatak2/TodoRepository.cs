using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            //return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(t=> t.Id==todoId).FirstOrDefault();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if(Get(todoItem.Id) != null)
            {
                throw new DuplicateTodoItemException(todoItem.Id);
            }

            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            if (Get(todoId) != null)
            {
                return _inMemoryTodoDatabase.Remove(Get(todoId));
            }
            return false;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if(Get(todoItem.Id) == null)
            {
                Add(todoItem);
            }
            else
            {
                Remove(todoItem.Id);
                Add(todoItem);
            }
            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (Get(todoId) != null)
            {
                return Get(todoId).MarkAsCompleted();
            }
            return false; 
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(t => t.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(t => t.IsCompleted == false).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(t => t.IsCompleted == true).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}
