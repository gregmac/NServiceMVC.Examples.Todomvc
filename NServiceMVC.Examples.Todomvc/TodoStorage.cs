using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NServiceMVC.Examples.Todomvc
{
    /// <summary>
    /// Sample in-memory list of TODOs
    /// </summary>
    public class TodoStorage
    {

        public TodoStorage() {
            Todos = new List<Models.Todo>();
        }

        private IList<Models.Todo> Todos;
        private Object Lock = new Object();

        public IEnumerable<Models.Todo> GetAll()
        {
            lock (Lock)
            {
                return Todos.ToArray();
            }
            
        }

        public void Add(Models.Todo item)
        {
            lock (Lock)
            {
                Todos.Add(item);
            }
        }

        private Models.Todo UnsafeGetById(Guid id)
        {
            return (from t in Todos
                    where t.Id == id
                    select t).FirstOrDefault();
        }

        public Models.Todo GetById(Guid id)
        {
            lock (Lock)
            {
                return UnsafeGetById(id);
            }
        }

        public bool Update(Guid id, Models.Todo data)
        {
            lock (Lock)
            {
                var item = UnsafeGetById(id);
                if (item == null)
                    return false;

                item.Text = data.Text;
                item.Done = data.Done;
                item.Order = data.Order;

                return true;
            }
        }

        public bool Delete(Guid id)
        {
            lock (Lock)
            {
                var item = UnsafeGetById(id);
                if (item == null)
                    return false;

                Todos.Remove(item);

                return true;
            }
        }

        public void DeleteAll()
        {
            lock (Lock)
            {
                Todos.Clear();
            }
        }

        public int Count()
        {
            lock (Lock)
            {
                return Todos.Count();
            }
        }
    }
}