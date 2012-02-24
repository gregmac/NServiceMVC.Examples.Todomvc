using System;
using System.Collections.Generic;
using System.Linq;
using NServiceMVC;
using AttributeRouting;
using System.ComponentModel;

namespace NServiceMVC.Examples.Todomvc.Controllers
{
    public class TodosController : ServiceController
    {
        private static IList<Models.Todo> Todos; // in-memory static list. Note no thread-safety!
        public TodosController()
        {
            if (Todos == null)
                Todos = new List<Models.Todo>(); // initialize the list if it's not already
        }

        [GET("todos")]
        [Description("List all Todos")]
        public IEnumerable<Models.Todo> Index()
        {
            return Todos;
        }

        [POST("todos")]
        [Description("Add a Todo")]
        public Models.Todo Add(Models.Todo item)
        {
            Todos.Add(item);
            return item;
        }

        [PUT("todos/{id}")]
        [Description("Update an existing Todo")]
        public object Update(Guid id, Models.Todo item)
        {
            var existing = (from t in Todos where t.Id == id select t).FirstOrDefault();
            if (existing != null)
                existing = item;
            return null;
        }

        [DELETE("todos/{id}")]
        [Description("Delete a Todo")]
        public object Delete(Guid id)
        {
            var existing = (from t in Todos where t.Id == id select t).FirstOrDefault();
            Todos.Remove(existing);
            return null;
        }
    }
}
