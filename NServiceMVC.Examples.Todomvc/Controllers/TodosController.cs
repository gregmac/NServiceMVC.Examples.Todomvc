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
        protected TodoStorage Todos; 
        public TodosController(TodoStorage todos)
        {
            Todos = todos; // injected by IoC container
        }

        [GET("todos")]
        [Description("List all Todos")]
        public IEnumerable<Models.Todo> Index()
        {
            return Todos.GetAll();
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
            if (!Todos.Update(id, item))
            {
                throw new ServiceException(new { Message = "Failed to find requested id to update" });
            }
            return null;
        }

        [DELETE("todos/{id}")]
        [Description("Delete a Todo")]
        public object Delete(Guid id)
        {
            if (!Todos.Delete(id))
            {
                throw new ServiceException(new { Message = "Failed to find requested id to delete" });
            }
            return null;
        }

    }
}
